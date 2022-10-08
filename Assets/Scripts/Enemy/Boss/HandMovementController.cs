using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovementController : MonoBehaviour
{
    //[SerializeField] private float _lerpSpeed = 0.05f;
    [SerializeField, Min(0.0f)] private float _speedMoveTowawards = 1f;
    [SerializeField] private float _distanceTreshold = 0.3f, yMin = -3.0f;
    [SerializeField] private Collider2D _area;

    private Vector2 target, center;
    private Rigidbody2D rb;
    private bool IsCircle = false;
    private float radius, angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(target, target + Vector2.one * 0.1f);
        if (IsCircle)
        {
            angle += Time.fixedDeltaTime * _speedMoveTowawards / radius;

            var x = Mathf.Cos(angle) * radius;
            var y = Mathf.Sin(angle) * radius;
            target = new Vector2(x, y) + center;
        }
        else
        {
            if ((rb.position - target).sqrMagnitude < _distanceTreshold)
                target = GetNextTarget();
        }
        rb.position = Vector2.MoveTowards(rb.position, target, _speedMoveTowawards * Time.fixedDeltaTime);
        //rb.position = FpsLerp.Lerp(rb.position, target,
        //                           _lerpSpeed, Time.fixedDeltaTime);
        //if ((rb.position - target).sqrMagnitude < _distanceTreshold)
        //    target = GetNextTarget();
    }

    public void StartCircle(float radius, float angle, Vector2 center)
    {
        IsCircle = true;
        this.radius = radius;
        this.angle = angle;
        this.center = center;

    }

    public void StopCircle()
    {
        IsCircle = false;
    }

    public void SetArea(Collider2D area)
    {
        _area = area;
    }

    public void AttackHero(float x)
    {
        target = new Vector2(x, yMin);
    }

    private Vector3 GetNextTarget()
    {
        var a = RandomExtentions.InBounds(_area.bounds);
        return a.y < yMin ? new Vector2(a.x, yMin) : a;
    }
}
