using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour, ITargetSetter
{
    public Vector2 CirclePoint = new Vector2(0.0f, 2.5f);
    public bool IsCircle = false;

    [SerializeField] private float _lerpSpeed = 0.05f, _distanceTreshold = 0.3f;
    [SerializeField] private Collider2D _area;

    private Bounds bounds;
    private Vector2 target;
    private Rigidbody2D rb;

    private void Awake()
    {
        bounds = _area.bounds;
        rb = GetComponent<Rigidbody2D>();
        target = GetNextTarget();
    }

    private void FixedUpdate()
    {
        rb.position = FpsLerp.Lerp(rb.position, target,
                                    _lerpSpeed, Time.fixedDeltaTime);
        if ((rb.position - target).sqrMagnitude < _distanceTreshold)
            target = IsCircle ? CirclePoint : GetNextTarget();
    }

    private Vector3 GetNextTarget() => RandomExtentions.InBounds(bounds);

    public void SetTarget(float x)
    {
        target = new Vector2(x, bounds.min.y);
    }
}
