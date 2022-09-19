using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Transform player;
    private bool isRight;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isRight = player.position.x < transform.position.x;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(player.position.x, transform.position.y), _speed * Time.deltaTime);
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
