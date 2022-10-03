using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Transform _frontLeg;
    [SerializeField] private Transform _backLeg;
    [SerializeField] private Transform _body;
    [SerializeField] private float _stepSpeed;
    [SerializeField] private float _bodyAmplitude;

    private Vector3 middlePoint;
    private Vector3 bodyPoint;
    private float r;

    private float phase;

    private void Start()
    {
        if (_body != null)
            bodyPoint = _body.localPosition;
        if (_frontLeg != null && _backLeg != null)
        {
            middlePoint = (_frontLeg.localPosition + _backLeg.localPosition) / 2;
            r = (middlePoint - _frontLeg.localPosition).magnitude;
        }
        phase = Random.value;
    }

    private void FixedUpdate()
    {
        phase += Time.fixedDeltaTime * _stepSpeed;
        if (_body != null)
            _body.localPosition = bodyPoint + Vector3.up * Mathf.Abs(Mathf.Sin(phase * Mathf.PI * 2)) * _bodyAmplitude;
        if (_frontLeg != null)
            _frontLeg.localPosition = middlePoint + Quaternion.Euler(0, 0, phase * 360) * Vector3.right * r;
        if (_backLeg != null)
            _backLeg.localPosition = middlePoint + Quaternion.Euler(0, 0, phase * 360) * Vector3.left * r;
    }
}
