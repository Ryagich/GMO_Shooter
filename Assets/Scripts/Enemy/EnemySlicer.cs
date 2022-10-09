using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
public class EnemySlicer : MonoBehaviour
{
    [SerializeField] Transform _slices;

    private void Start()
    {
        GetComponent<EnemyHp>().OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        var count = _slices.childCount;
        for (int i = 0; i < count; i++)
        {
            var child = _slices.GetChild(i);
            child.gameObject.AddComponent<SliceParticle>();
        }
        _slices.SetParent(null);
        _slices.gameObject.SetActive(true);
    }
}
