using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public bool CanTakeDamage => _hp > 0;

    [SerializeField] [Min(0.0f)] private float _maxHp = 100.0f;
    [SerializeField] [Min(0.0f)] private float _hp = 100.0f;
    [SerializeField] private Image _health;
    [SerializeField] float _layingTreshold = 80f;

    public float DEBUG = 0;

    public void TakeDamage(float damage)
    {
        if (_hp - damage <= 0)
            Death();
        _hp -= _hp - damage >= 0 ? damage : _hp;
        UpdateHpBar();
    }

    public void Death()
    {
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
