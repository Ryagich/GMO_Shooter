using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSaver : MonoBehaviour
{
    [SerializeField] private WeaponsManager _pistolManager;
    [SerializeField] private WeaponsManager _rifleManager;
    [SerializeField] private WeaponsManager _shotGunManager;

    public void SaveSelectedWeapons()
    {
        Data.SelectedPistol = _pistolManager.GetSelectedWeapon();
        Data.SelectedRifle = _rifleManager.GetSelectedWeapon();
        Data.SelectedShotGun = _shotGunManager.GetSelectedWeapon();
    }
}
