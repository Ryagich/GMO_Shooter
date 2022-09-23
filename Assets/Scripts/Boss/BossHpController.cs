using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHpController : MonoBehaviour
{
    public bool CanTakeDamage = true, CanAttacked = true;

    [SerializeField] private float _maxHp = 100.0f, _hp = 100.0f;
    [SerializeField] private Image _hpBar;

    public void TakeDamage(float damage)
    {
        if (CanTakeDamage)
        {
            _hp -= _hp - damage >= 0 ? damage : _hp;
            UpdateHpBar();
        }
    }

    private void UpdateHpBar()
    {
        _hpBar.fillAmount = _hp / _maxHp;
    }
}
