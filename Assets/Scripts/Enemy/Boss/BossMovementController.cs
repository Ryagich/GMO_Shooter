using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour, ITargetSetter
{
    [SerializeField]
    private float _lerpSpeed = 0.05f, _range = 2.0f,
                                    _distanceTreshold = 0.3f;
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
        var delta = target - rb.position;
        rb.position = FpsLerp
            .Lerp(rb.position, target, _lerpSpeed, Time.fixedDeltaTime);
        if ((rb.position - target).sqrMagnitude < _distanceTreshold)
            target = GetNextTarget();
    }

    private Vector3 GetNextTarget() => RandomExtentions.InBounds(bounds);

    public void SetTarget(float x)
    {
        target = new Vector2(x, bounds.min.y);
        Debug.Log(target.x + " " + target.y);
        Debug.Log("Was SetTarget");
    }
}
