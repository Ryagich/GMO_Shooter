using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 500.0f;

    private Vector2 movement = new Vector2();
    private Rigidbody2D physic;

    private void Awake()
    {
        _speed *= Data.SpeedUpdate.Update;
        physic = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rigidbody2D.AddForce(movement * Speed * Time.deltaTime);
        physic.velocity = movement * _speed * Time.deltaTime;
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }
}
