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
        return Mathf.Max(GetMaxSpeedFromWeaponType(_pistolsManager.WeaponTypes),
                         GetMaxSpeedFromWeaponType(_rifleManager.WeaponTypes),
                         GetMaxSpeedFromWeaponType(_shotGunManager.WeaponTypes));
    }

    public float GetMaxDamage()
    {
        return Mathf.Max(GetMaxDamageFromWeaponType(_pistolsManager.WeaponTypes),
                         GetMaxDamageFromWeaponType(_rifleManager.WeaponTypes),
                         GetMaxDamageFromWeaponType(_shotGunManager.WeaponTypes));
    }

    private float GetMaxSpeedFromWeaponType(WeaponInfo[] weapons)
    {
        var maxSpeed = 0.0f;
        for (var i = 0; i < weapons.Length; i++)
            maxSpeed = Mathf.Max(weapons[i].Weapon.AttackCooldown, maxSpeed);
        return maxSpeed;
    }

    private float GetMaxDamageFromWeaponType(WeaponInfo[] weapons)
    {
        var maxAttack = 0.0f;
        for (var i = 0; i < weapons.Length; i++)
            maxAttack = Mathf.Max(weapons[i].Weapon.Damage, maxAttack);
        return maxAttack;
    }
}
