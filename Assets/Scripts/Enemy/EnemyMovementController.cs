using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _acceleration = 1.0f;
    [SerializeField] private float _rotationLerp = 1.0f;

    private Transform player;
    private bool isRight;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isRight = player.position.x < transform.position.x;
    }

    private void FixedUpdate()
    {
        var targetVelocity = (isRight ? Vector2.right : Vector2.left) * _speed;
        rb.velocity = Vector2.MoveTowards(rb.velocity, targetVelocity, _acceleration * Time.deltaTime);
        rb.MoveRotation(FpsLerp.Lerp(rb.rotation, 0, _rotationLerp, Time.deltaTime));
        Flip();
    }

    private void Flip()
    {
        if (player.position.x < transform.position.x && isRight)
        {
            isRight = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (player.position.x > transform.position.x && !isRight)
        {
            isRight = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
