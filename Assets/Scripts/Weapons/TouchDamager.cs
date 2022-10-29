using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamager : MonoBehaviour
{
    [SerializeField] private float _knockback;
    [SerializeField] private float _damage = 5.0f;

    private void DealDamage(Collider2D collider)
    {
        var damageable = collider.gameObject.GetComponent<Damageable>();
        var rb = collider.gameObject.GetComponent<Rigidbody2D>();
        if (damageable == null || !damageable.CanTakeDamage)
            return;
        damageable.TakeDamage(_damage);
        Destroy(gameObject);
        if (rb == null)
            rb.AddForceAtPosition(transform.right * _knockback, transform.position);
        
    }

    public void SetDamage(float dmg) => _damage = dmg;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DealDamage(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DealDamage(collider);
    }
}
