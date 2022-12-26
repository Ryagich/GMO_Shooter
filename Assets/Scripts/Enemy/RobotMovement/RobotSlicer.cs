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
        var children = ChildEnumerator.EnumerateChildrenRecursive(transform);
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
}
