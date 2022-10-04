using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(EnemyCharger))]
[RequireComponent(typeof(EnemyHp))]

public class BossStateController : MonoBehaviour
{
    [SerializeField, Min(0.0f)] private float _cooldownTime = 5.0f;

    private EnemyHp hpController;
    private Damageable damageble;
    private EnemyCharger charger;
    private States state = States.Idle;
    private bool isIdle = true, isDefended = false;
    private float hpCoefficient;

    private void Awake()
    {
        damageble = GetComponent<Damageable>();
        hpController = GetComponent<EnemyHp>();
        charger = GetComponent<EnemyCharger>();

        damageble.OnDamage += ActiveState;
        damageble.OnDamage += ReduceCooldownTime;

        hpCoefficient = hpController.HP / hpController.MaxHP;

        UseAbility();
    }

    private void ActiveState(float _)
    {
        if (hpCoefficient.Equals(0.95f))
            state = States.Charger;
    }

    private void UseAbility()
    {
        if (state != States.Idle)
        {
            charger.Charge();
        }
        StartCoroutine(Cooldown());
    }

    private void ReduceCooldownTime(float _)
    {

    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        UseAbility();
    }

    private enum States
    {
        Idle = 0,
        Charger = 1,
    }
}
