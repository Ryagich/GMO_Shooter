using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private bool _useMobileInput;
    [SerializeField] private HoverButton _left;
    [SerializeField] private HoverButton _right;
    [SerializeField] private float _speed = 5.0f;

    private Vector2 movement = new Vector2();
    private Rigidbody2D physic;

    private void Awake()
    {
        //_speed *= Data.SpeedUpdate.Update;
        physic = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rigidbody2D.AddForce(movement * Speed * Time.deltaTime);
        physic.velocity = movement * _speed;
    }

    private void Update()
    {
        if (_useMobileInput && _left != null && _right != null)
        {
            movement = Vector2.zero;
            movement.x -= _left.IsPressed ? 1 : 0;
            movement.x += _right.IsPressed ? 1 : 0;
        }
        else
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
    }
}
