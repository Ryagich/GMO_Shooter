using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1.0f;
    private float damage = 5.0f;
    private float time = 1.0f;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, time);
    }

    public void SetStats(float speedV, float damageV, float time)
    {
        speed = speedV;
        damage = damageV;
        this.time = time;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null && damageable.CanTakeDamage)
            damageable.TakeDamage(damage);
        Destroy(gameObject);
    }
}
