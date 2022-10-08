using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
public class Enemy : MonoBehaviour
{
    private EnemyHp hp;

    private void Start()
    {
        hp = GetComponent<EnemyHp>();
        GetComponent<EnemyHp>().OnDeath += Death;
        if (GetComponent<Layer>() != null)
            GetComponent<Layer>().OnLayed += Death;

    }

    private void Death()
    {
        if (EnemyKillCounter.Instance != null)
            EnemyKillCounter.Instance.Count++;
        Destroy(gameObject);
    }
}
