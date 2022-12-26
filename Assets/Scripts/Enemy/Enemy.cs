using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
public class Enemy : MonoBehaviour
{
    private EnemyHp hp;
    private Damageable damageable;
    private SoundPlayer player;

    private void Start()
    {
        hp = GetComponent<EnemyHp>();
        damageable = GetComponent<Damageable>();
        player = GetComponent<SoundPlayer>();
        GetComponent<EnemyHp>().OnDeath += Death;
        if (GetComponent<Layer>() != null)
            GetComponent<Layer>().OnLayed += Death;
        damageable.OnDamage += (_) => { player.Play(); };
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
