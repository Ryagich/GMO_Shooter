using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null && damageable.CanTakeDamage)
            damageable.TakeDamage(_damage);
    }
}
