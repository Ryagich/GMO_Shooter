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
    [SerializeField] private Rigidbody2D _rigidbody;

    private float phase = 0;

    private Vector2 bodyOrigin,
                    frontLegOrigin,
                    backLegOrigin,
                    headOrigin;

    private void Start()
    {
        bodyOrigin = _body.localPosition;
        frontLegOrigin = _frontLeg.localPosition;
        backLegOrigin = _backLeg.localPosition;
        headOrigin = _head.localPosition;
    }

    private void FixedUpdate()
    {
        var d = _rigidbody.velocity.x * Time.fixedDeltaTime * _timeMultiplier;
        phase += d;
        phase %= Mathf.PI * 2;

        if (Mathf.Abs(d) < _idleTreshold)
            phase = Mathf.Deg2Rad * Mathf.LerpAngle(Mathf.Rad2Deg * phase, 0, 0.1f);

        var absSin = Mathf.Abs(Mathf.Sin(phase));
        var sin2 = Mathf.Sin(phase * 2);

        _body.SetLocalPosition2D(absSin * _bodyAmplitude * Vector2.up + bodyOrigin);
        _head.SetLocalPosition2D(absSin * _headAmplitude * Vector2.down + headOrigin);
        _tail.SetLocalRotation2D(-absSin * _tailAngle);

        _frontLeg.SetLocalPosition2D(Mathf.Sin(phase * 2) * _legAmplitude * Vector2.down + frontLegOrigin, 0);
        _frontLeg.SetLocalRotation2D(sin2 * _legAngle);

        _backLeg.SetLocalPosition2D(Mathf.Sin(phase * 2) * _legAmplitude * Vector2.up + backLegOrigin, 0);
        _backLeg.SetLocalRotation2D(-sin2 * _legAngle);
    }
}
