using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public static event Action OnHeroDied;
    [SerializeField][Min(1.0f)] private float _maxHp = 100.0f;
    [SerializeField][Min(1.0f)] private float _hp = 100.0f;
    [SerializeField] private Image _health;

    private CoinsManager coinsManager;
    private WeaponInventory weaponInventory;

    private void Awake()
    {
        //_maxHp *= Data.HpUpdate.Update;
        //_hp *= Data.HpUpdate.Update;
        coinsManager = GetComponent<CoinsManager>();
        weaponInventory = GetComponent<WeaponInventory>();
    }

    public void TakeDamage(float damage)
    {
        _hp -= _hp - damage >= 0 ? damage : _hp;
        if (_hp == 0)
            Death();
        UpdateHpBar();
    }

    public void TakeHp(float hp)
    {
        _hp = _hp + hp >= _maxHp ? _maxHp : _hp + hp;
        UpdateHpBar();
    }

    private void Death()
    {
        OnHeroDied?.Invoke();
    }

    private void UpdateHpBar()
    {
        _health.fillAmount = _hp / _maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObj = collision.gameObject;
        if (collisionObj.layer != LayerMask.NameToLayer("Collectable"))
            return;
        var collectable = collisionObj.GetComponent<Collectable>();
        if (!collectable)
            return;
        switch (collectable.CollectableType)
        {
            case Collectable.Type.Heart:
                // TODO: ADD HP
                break;
            case Collectable.Type.Coin:
                coinsManager.AddCoins(collectable.Value);
                break;
            case Collectable.Type.ShotGunBullets:
                weaponInventory.AddBullets(weaponInventory.ShotGun, collectable.Value);
                break;
            case Collectable.Type.RifleBullets:
                weaponInventory.AddBullets(weaponInventory.Rifle, collectable.Value);
                break;
        }
        collectable.Collect();        
    }
}
