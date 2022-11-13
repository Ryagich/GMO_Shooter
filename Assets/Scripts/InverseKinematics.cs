using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
public class InverseKinematics : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _upperArm, _forearm;
    [SerializeField] private Transform _joint1, _joint2;
    [SerializeField] private Transform _from, _to;
    [SerializeField] private bool _useBottomJoint = false;

    // O==== upperArm ====O==== Forearm ==== Target

    private Transform transform1, transform2;
    private Vector3 size1, size2;

    private void Start()
    {
        size1 = _upperArm.localBounds.size * _upperArm.transform.lossyScale.x;
        size2 = _forearm.localBounds.size * _forearm.transform.lossyScale.x;
        transform1 = _upperArm.transform;
        transform2 = _forearm.transform;
    }

    private void FixedUpdate()
    {
        var jointPosition = GetIntersections(transform1.position,
                                             _to.position,
                                             size1.y,
                                             size2.y);
        transform2.position = CopyXY(jointPosition, transform2.position);
        transform2.localRotation = FromTo2d(transform.TransformVector(transform2.position),
                                            transform.TransformVector(_to.position));
        transform1.localRotation = FromTo2d(transform.TransformVector(transform1.position),
                                            transform.TransformVector(jointPosition));
        transform1.position = _from.position;
        _joint2.position = CopyXY(jointPosition, _joint2.position);
        _joint1.position = CopyXY(_from.position, _joint1.position);
        Debug.DrawLine(_from.position, _to.position);
    }

    private Quaternion FromTo2d(Vector2 from, Vector2 to)
    {
        var direction = from - to;
        return Quaternion.LookRotation(Vector3.forward, direction);
    }

    private Vector3 CopyXY(Vector3 from, Vector3 to)
    {
        to.Set(from.x, from.y, to.z);
        return to;
    }

    private Vector2 GetIntersections(Vector2 posA, Vector2 posB, float radiusA, float radiusB)
    {
        var deltaPos = posB - posA;
        var deltaRadius = radiusB - radiusA;
        var distance = deltaPos.magnitude;
        if (distance > radiusA + radiusB
            || distance < Mathf.Abs(deltaRadius)
            || posA == posB)
            return Vector2.Lerp(posA, posB, 0.5f);
        var r1Sqr = radiusA * radiusA;
        var distanceSqr = distance * distance;
        var distanceToMiddle = 0.5f * (r1Sqr - radiusB * radiusB) / distanceSqr + 0.5f;
        var middle = posA + deltaPos * distanceToMiddle;
        var discriminant = r1Sqr / distanceSqr - distanceToMiddle * distanceToMiddle;
        var offset = (Vector2)(Quaternion.Euler(0, 0, -90) * deltaPos * Mathf.Sqrt(discriminant));
        var i1 = middle + offset;
        var i2 = middle - offset;
        return ((i1.y > i2.y) ^ _useBottomJoint) ? i1 : i2;
    }
}