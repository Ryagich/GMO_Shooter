using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    class ScriptableObjectSerializer
    {
        private static ScriptableObjectSerializer instance;

        private Dictionary<ResourceId, ScriptableObject> scriptables;

        public ScriptableObjectSerializer()
        {
            scriptables = new Dictionary<ResourceId, ScriptableObject>();
            var resources = Resources.LoadAll<ScriptableObject>(String.Empty);
            foreach (var resource in resources)
            {
                if (resource is not ISaveId id)
                    continue;
                var type = resource.GetType();
                var resId = new ResourceId(id.Id, type);
                scriptables.Add(resId, resource);
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            var t = typeof(T);
            foreach (var s in scriptables)
            {
                if (s.Key.Type == t)
                    yield return (T)(object)s.Value;
            }
        }

        public T Get<T>(string Id)
        {
            var scriptable = scriptables[new ResourceId(Id, typeof(T))];
            var t = (T)(object)scriptable;
            return t;
        }

        public static ScriptableObjectSerializer GetInstance()
        {
            instance ??= new ScriptableObjectSerializer();
            return instance;
        }
    }

    class ResourceId
    {
        public string Id;
        public Type Type;

        public ResourceId(string id, Type type)
        {
            Id = id;
            Type = type;
        }

        public override string ToString()
        {
            return String.Join('.', new object[] { Id, Type });
        }

        public override bool Equals(object obj)
        {
            if (obj is not ResourceId other)
                return false;
            return other.ToString() == ToString();
        }

        public override int GetHashCode() => ToString().GetHashCode();
    }
}
