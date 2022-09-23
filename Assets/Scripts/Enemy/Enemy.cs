using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public bool CanTakeDamage => _hp > 0;

    [SerializeField] [Min(0.0f)] private float _maxHp = 100, _hp = 100, _layingTreshold = 80;
    [SerializeField] private Image _health;


    public void TakeDamage(float damage)
    {
        _hp -= _hp - damage >= 0 ? damage : _hp;
        UpdateHpBar();
        if (_hp <= 0)
            Death();
    }

    public void Death()
    {
        EnemyKillCounter.Instance.count++;
        Destroy(gameObject);
    }

    private void UpdateHpBar()
    {
        _health.fillAmount = _hp / _maxHp;
    }

    private void Update()
    {
        if (IsLaying())
            Death();
    }

    private bool IsLaying()
    {
        var d = Mathf.DeltaAngle(transform.eulerAngles.z, 0);        
        var r = Mathf.Abs(d) > _layingTreshold;
        return r;
    }
}
