using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public event Action OnLayed;

    [SerializeField] private float _layingTreshold = 80.0f;

    private void Update()
    {
        if (IsLaying())
            OnLayed?.Invoke();
    }

    private bool IsLaying()
    {
        var d = Mathf.DeltaAngle(transform.eulerAngles.z, 0);
        var r = Mathf.Abs(d) > _layingTreshold;
        return r;
    }
}
