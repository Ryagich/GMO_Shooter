using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsShower : MonoBehaviour
{
    [SerializeField] private Text RifleText;
    [SerializeField] private Text ShotGunText;
    [SerializeField] private WeaponInventory WeaponInventory;

    private void Start()
    {
        //WeaponInventory
        //    .Rifle
        //    .BulletsController
        //    .OnBulletCountUpdated += (a => { RifleText.text = a.ToString(); });
        //WeaponInventory
        //    .ShotGun
        //    .BulletsController
        //    .OnBulletCountUpdated += (a => { ShotGunText.text = a.ToString(); });
    }
}
