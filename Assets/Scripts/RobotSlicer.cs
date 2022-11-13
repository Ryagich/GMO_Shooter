using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSlicer : MonoBehaviour
{   
    private void Start()
    {
        GetComponent<EnemyHp>().OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        System.Console.WriteLine(transform);
        var children = EnumerateChildrenReccurent(transform);
        foreach (var child in children)
        {
            var sr = child.GetComponent<SpriteRenderer>();
            if (!sr)
                continue;
            var obj = new GameObject();
            obj.transform.SetParent(null);
            obj.transform.SetPositionAndRotation(child.transform.position, child.transform.rotation);
            obj.transform.localScale = child.transform.lossyScale;
            obj.AddComponent<SpriteRenderer>().sprite = sr.sprite;
            obj.AddComponent<SliceParticle>();
        }
        transform.Translate(Vector2.zero);
    }

    private static IEnumerable<Transform> EnumerateChildrenReccurent(Transform parent)
    {
        System.Console.WriteLine(parent);
        var count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
            var child = parent.GetChild(i);            
            yield return child;
            foreach (var trans in EnumerateChildrenReccurent(child))
                yield return trans;
        }
    }
}
