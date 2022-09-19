using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public Weapon Pistol { get; private set; }
    public Weapon Rifle { get; private set; }
    public Weapon ShotGun { get; private set; }
    public Weapon CurrentWeapon { get; private set; }

    [SerializeField] private Transform _gunPoint;

    private Weapons numWeapon;
    private BulletsShower bulletsShower;

    private void Awake()
    {
        Pistol = Instantiate(Data.SelectedPistol, _gunPoint);
        Rifle = Instantiate(Data.SelectedRifle, _gunPoint);
        ShotGun = Instantiate(Data.SelectedShotGun, _gunPoint);

        Rifle.gameObject.SetActive(false);
        ShotGun.gameObject.SetActive(false);
        Pistol.gameObject.SetActive(false);
        ChangeWeapon(Pistol);

        Pistol.BulletsController = new BulletsController(int.MaxValue, int.MaxValue);
        Rifle.BulletsController = new BulletsController(0, 60);
        ShotGun.BulletsController = new BulletsController(0, 30);

        Pistol.SetInpulse(GetComponent<Cinemachine.CinemachineCollisionImpulseSource>());
        ShotGun.SetInpulse(GetComponent<Cinemachine.CinemachineCollisionImpulseSource>());
        Rifle.SetInpulse(GetComponent<Cinemachine.CinemachineCollisionImpulseSource>());

        bulletsShower = GetComponent<BulletsShower>();
        bulletsShower.UpdateText(Rifle.BulletsController.CurrentCount,
                               ShotGun.BulletsController.CurrentCount);//костыль

        Rifle.BulletsController.OnHaveBullets.AddListener(a => { CheckRifleBullets(a); });
        ShotGun.BulletsController.OnHaveBullets.AddListener(a => { CheckShotGunBullets(a); });
    }

    private void CheckRifleBullets(bool hasBullets)
    {
        if (!hasBullets && numWeapon == Weapons.Rifle)
            ChangeWeaponToShotGun();
    }

    private void CheckShotGunBullets(bool hasBullets)
    {
        if (!hasBullets && numWeapon == Weapons.ShotGun)
            ChangeWeaponToRifle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeaponToPistol();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeaponToRifle();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeaponToShotGun();
    }
    public void AddRifleBullets(int value)
    {
        Rifle.BulletsController.AddBullets(value);
        if (numWeapon == Weapons.Pistol)
        {
            ChangeWeapon(Rifle);
            numWeapon = Weapons.Rifle;
        }
    }

    public void AddShotGunBullets(int value)
    {
        ShotGun.BulletsController.AddBullets(value);
        if (numWeapon == Weapons.Pistol)
        {
            ChangeWeapon(ShotGun);
            numWeapon = Weapons.ShotGun;
        }
    }

    #region Changers
    private void ChangeWeaponToShotGun()
    {
        if (ShotGun.BulletsController.HasBullets)
        {
            if (numWeapon != Weapons.ShotGun)
            {
                ChangeWeapon(ShotGun);
                numWeapon = Weapons.ShotGun;
            }
            else if (numWeapon == Weapons.ShotGun)
                return;
        }
        else if (numWeapon == Weapons.Rifle && Rifle.BulletsController.HasBullets)
            return;
        else
            ChangeWeaponToPistol();
    }

    private void ChangeWeaponToRifle()
    {
        if (Rifle.BulletsController.HasBullets)
        {
            if (numWeapon != Weapons.Rifle)
            {
                ChangeWeapon(Rifle);
                numWeapon = Weapons.Rifle;
            }
            else if (numWeapon == Weapons.Rifle)
                return;
        }
        else if (numWeapon == Weapons.ShotGun && ShotGun.BulletsController.HasBullets)
            return;
        else
            ChangeWeaponToPistol();
    }

    private void ChangeWeaponToPistol()
    {
        if (numWeapon != Weapons.Pistol)
        {
            ChangeWeapon(Pistol);
            numWeapon = Weapons.Pistol;
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        CurrentWeapon?.gameObject.SetActive(false);
        weapon.gameObject.SetActive(true);
        CurrentWeapon = weapon;
    }
    #endregion
}

public enum Weapons
{
    Pistol = 0,
    Rifle = 1,
    ShotGun
}
