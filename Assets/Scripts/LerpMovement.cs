using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public float MaxSpeed = 1.0f;
    public float SpeedMultiplier = 1.0f;
    public Vector3 Target;

    public event Action OnTargetReached;

    [SerializeField] private float _distanceTreshold = 0.3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var distance = Vector2.Distance(Target, transform.position);
        if (rb != null)
            rb.velocity = Vector2.ClampMagnitude(Target - transform.position, MaxSpeed) * SpeedMultiplier;
        else
            transform.position = Vector2.Lerp(transform.position, Target, SpeedMultiplier);
        if (distance < _distanceTreshold)
            OnTargetReached?.Invoke();
    }
}
