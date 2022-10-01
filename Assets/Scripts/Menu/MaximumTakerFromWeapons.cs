using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaximumTakerFromWeapons : MonoBehaviour
{
    [SerializeField] private WeaponsManager _pistolsManager;
    [SerializeField] private WeaponsManager _rifleManager;
    [SerializeField] private WeaponsManager _shotGunManager;

    public float GetMaxSpeed()
    {
        return Mathf.Max(GetMaxSpeed(_pistolsManager.WeaponTypes),
                         GetMaxSpeed(_rifleManager.WeaponTypes),
                         GetMaxSpeed(_shotGunManager.WeaponTypes));
    }

    public float GetMaxDamage()
    {
        return Mathf.Max(GetMaxDamage(_pistolsManager.WeaponTypes),
                         GetMaxDamage(_rifleManager.WeaponTypes),
                         GetMaxDamage(_shotGunManager.WeaponTypes));
    }

    private float GetMaxSpeed(WeaponInfo[] weapons)
    {
        var maxSpeed = 0.0f;
        for (var i = 0; i < weapons.Length; i++)
            maxSpeed = Mathf.Max(weapons[i].Weapon.AttackCooldown, maxSpeed);
        return maxSpeed;
    }

    private float GetMaxDamage(WeaponInfo[] weapons)
    {
        var maxAttack = 0.0f;
        for (var i = 0; i < weapons.Length; i++)
            maxAttack = Mathf.Max(weapons[i].Weapon.Damage, maxAttack);
        return maxAttack;
    }
}
