using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyHp))]
[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(EnemyCharger))]
[RequireComponent(typeof(LazerController))]

public class BossStateController : MonoBehaviour
{
    [SerializeField, Min(0.0f)] private float _cooldownTime = 5.0f;
    [SerializeField] private List<UnityEvent> _states;
    [SerializeField, Range(0.0f, 1.0f)] private List<float> _tresholds;

    private EnemyHp hpController;
    private Damageable damageble;
    private int stateIndex = -1;
    private float cooldown;

    private void Awake()
    {
        cooldown = _cooldownTime;
        damageble = GetComponent<Damageable>();
        hpController = GetComponent<EnemyHp>();

        damageble.OnDamage += ChangeState;

        StartCoroutine(Cooldown());
    }

    private void ChangeState(float _)
    {
        var hpCoefficient = hpController.HP / hpController.MaxHP;
        for (int i = 0; i < _tresholds.Count; i++)
        {
            if (hpCoefficient < _tresholds[i])
                stateIndex = i;
        }
        cooldown = _cooldownTime * hpCoefficient + 2;
    }

    private IEnumerator Cooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            UseAbility();
        }
    }

    private void UseAbility()
    {
        if (stateIndex >= 0)
            _states[Random.Range(0, stateIndex)].Invoke();
    }
}
