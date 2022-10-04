using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public event Action OnDeath;
    public float MaxHP { get => _maxHp; }
    public float HP { get => _hp; }

    [SerializeField, Min(0.0f)] private float _maxHp = 100;
    [SerializeField, Min(0.0f)] private float _hp = 100;
    [SerializeField] private Image _hpBar;

    private void Start()
    {
        var damageable = GetComponent<Damageable>();
        damageable.OnDamage += TakeDamage;
    }

    public void TakeDamage(float damage)
    {
        _hp -= _hp - damage >= 0 ? damage : _hp;
        UpdateHpBar();
        if (_hp <= 0)
            OnDeath?.Invoke();
    }

    private void UpdateHpBar()
    {
        if (_hpBar != null)
            _hpBar.fillAmount = _hp / _maxHp;
    }
}
