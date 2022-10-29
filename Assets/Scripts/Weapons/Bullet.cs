using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TouchDamager))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float time = 1.0f;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetStats(float speed, float damage, float time)
    {
        this.speed = speed;
        this.time = time;
        Destroy(gameObject, time);
        GetComponent<TouchDamager>().SetDamage(damage);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Time.deltaTime * speed * transform.right ;
    }
}
