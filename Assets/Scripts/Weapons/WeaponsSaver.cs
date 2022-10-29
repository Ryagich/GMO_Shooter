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
        var data = PlayerPrefsWrapper.LoadPrefs();
        data.SelectedPistol = _pistolManager.GetSelectedWeapon();
        data.SelectedRifle = _rifleManager.GetSelectedWeapon();
        data.SelectedShotGun = _shotGunManager.GetSelectedWeapon();
        PlayerPrefsWrapper.SavePrefs(data);
    }
}
