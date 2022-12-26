using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private bool _useMobileInput;
    [SerializeField] private HoverButton _left;
    [SerializeField] private HoverButton _right;
    [SerializeField] private float _speed = 5.0f;

    private Vector2 movementDirection;
    private Rigidbody2D physic;

    private void Awake()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var velocity = movementDirection.normalized * _speed;
        physic.velocity = Vector2.Lerp(physic.velocity, velocity, 0.5f);
    }

    private void Update()
    {
        if (_useMobileInput && _left != null && _right != null)
        {
            movementDirection = Vector2.zero;
            movementDirection.x -= _left.IsPressed ? 1 : 0;
            movementDirection.x += _right.IsPressed ? 1 : 0;
        }
        else
        {
            movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
    }
}
