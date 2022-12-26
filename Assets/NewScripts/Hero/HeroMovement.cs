using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed, _dragX;
    [SerializeField] private Transform _graphics;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var movement = InputHandler.Horizontal * _speed;
        if (movement == 0)
            rb.velocity = rb.velocity.ScaledX(1 - _dragX);
        else
            rb.velocity = rb.velocity.WithX(movement);
    }
}
