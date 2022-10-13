using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    [SerializeField] private float _timeMultiplier;
    [SerializeField] private float _idleTreshold;
    [SerializeField] private float _idleReturnSpeed;
    [SerializeField] private Transform _frontLeg;
    [SerializeField] private Transform _backLeg;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _tail;
    [SerializeField] private float _bodyAmplitude;
    [SerializeField] private float _headAmplitude;
    [SerializeField] private float _legAmplitude;
    [SerializeField] private float _tailAngle;
    [SerializeField] private float _legAngle;

    private Rigidbody2D rb;

    private float phase = 0;

    private Vector3 bodyPoint,
                    frontLegPoint,
                    backLegPoint,
                    headPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyPoint = _body.localPosition;
        frontLegPoint = _frontLeg.localPosition;
        backLegPoint = _backLeg.localPosition;
        headPoint = _head.localPosition;
    }

    private void FixedUpdate()
    {
        var d = rb.velocity.x * Time.fixedDeltaTime * _timeMultiplier;
        phase += d;
        phase %= Mathf.PI;
        
        if (Mathf.Abs(d) < _idleTreshold)
        {
            phase *= Mathf.Rad2Deg;
            phase = Mathf.Lerp(phase, 0, 0.9f);
            phase = Mathf.MoveTowardsAngle(phase, 0, Time.fixedDeltaTime * 80);
            phase *= Mathf.Deg2Rad;
        }   
            

        _body.localPosition = bodyPoint + Vector3.up * Mathf.Abs(Mathf.Sin(phase * Mathf.PI)) * _bodyAmplitude;
        _head.localPosition = headPoint + Vector3.down * Mathf.Abs(Mathf.Sin(phase * Mathf.PI)) * _headAmplitude;
        _tail.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sin(phase * Mathf.PI) * _tailAngle);

        _frontLeg.transform.localPosition = frontLegPoint + Vector3.down * Mathf.Sin(phase * 2 * Mathf.PI) * _legAmplitude;
        _frontLeg.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(phase * 2 * Mathf.PI) * _legAngle);

        _backLeg.transform.localPosition = backLegPoint + Vector3.up * Mathf.Sin(phase * 2 * Mathf.PI) * _legAmplitude; ;
        _backLeg.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sin(phase * 2 * Mathf.PI) * _legAngle);


    }
}
