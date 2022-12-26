using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChildEnumerator
{
    public static IEnumerable<Transform> EnumerateChildrenRecursive(Transform parent)
    {
        var count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
            var child = parent.GetChild(i);            
            foreach (var trans in EnumerateChildrenRecursive(child))
                yield return trans;
            yield return child;
        }
    }
}
