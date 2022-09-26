using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1.0f, damage = 5.0f, time = 1.0f;
    private LayerMask mask;
    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyAfterTime(time));
    }

    public void SetStats(float speedV, float damageV, float time, LayerMask mask)
    {
        this.mask = mask;
        speed = speedV;
        damage = damageV;
        this.time = time;
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        rigidbody2D.velocity = transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null && damageable.CanTakeDamage)
            damageable.TakeDamage(damage);        
        StopCoroutine("DestroyAfterTime");
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
