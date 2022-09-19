using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BulletsShower : MonoBehaviour
{
    [SerializeField] private Text RifleText;
    [SerializeField] private Text ShotGunText;
    [SerializeField] private WeaponInventory WeaponInventory;

    private void Start()
    {
        WeaponInventory.Rifle.BulletsController.OnBulletCountUpdated.AddListener(a => { RifleText.text = a.ToString(); });
        WeaponInventory.ShotGun.BulletsController.OnBulletCountUpdated.AddListener(a => { ShotGunText.text = a.ToString(); });
    }

    public void UpdateText(int automateBullets, int shotGunBullets)
    {
        RifleText.text = automateBullets.ToString();
        ShotGunText.text = shotGunBullets.ToString();
    }
}
