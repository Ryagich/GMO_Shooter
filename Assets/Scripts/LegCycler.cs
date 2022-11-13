using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCycler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _radius, _speed, _offset;
    private Vector2 startPos;

    private void Start()
    {
        startPos = _target.localPosition;
    }

    void FixedUpdate()
    {
        var time = -_speed * Time.time * 360 + _offset;
        var offset = (Vector2)(Quaternion.Euler(0, 0, time) * Vector2.right * _radius);
        offset.y = Mathf.Max(0, offset.y);
        var localTarget = startPos + offset;
        _target.localPosition = Vector3.Lerp(_target.localPosition, localTarget, 0.8f);
    }
}
