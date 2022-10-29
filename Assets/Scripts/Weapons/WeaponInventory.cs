using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
[RequireComponent(typeof(BulletsShower))]
public class WeaponInventory : MonoBehaviour
{
    public Weapon Pistol { get; private set; }
    public Weapon Rifle { get; private set; }
    public Weapon ShotGun { get; private set; }
    public Weapon ActiveWeapon { get; private set; }


    [SerializeField] private Transform _gunPoint;

    private Data data;
    private BulletsShower bulletsShower;
    private CinemachineImpulseSource impulseSource;
    private List<Weapon> weapons;

    private void Awake()
    {
        data = PlayerPrefsWrapper.LoadPrefs();
        bulletsShower = GetComponent<BulletsShower>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        weapons = new List<Weapon>();
        CreateWeapons();
        SetActiveWeapon(Pistol);
    }

    private void CreateWeapons()
    {
        Pistol = CreateWeapon(data.SelectedPistol);
        Rifle = CreateWeapon(data.SelectedRifle);
        ShotGun = CreateWeapon(data.SelectedShotGun);
        weapons.Sort((a, b) => b.DPS.CompareTo(a.DPS));
    }

    private Weapon CreateWeapon(Weapon weaponPrefab)
    {
        var w = Instantiate(weaponPrefab, _gunPoint);
        w.SetImpulseSource(impulseSource);
        w.BulletsController.OnOutOfBullets += SetBestWeapon;
        weapons.Add(w);
        return w;
    }

    public void SetActiveWeapon(Weapon activeWeapon)
    {
        ActiveWeapon = activeWeapon;
        foreach (var w in weapons)
            w.gameObject.SetActive(false);
        activeWeapon.gameObject.SetActive(true);
    }

    private void SetBestWeapon()
    {
        SetActiveWeapon(GetBestAvailableWeapon());
    }

    private Weapon GetBestAvailableWeapon()
    {
        var w = weapons.Where(w => w.BulletsController.HasBullets).ToList();
        return w.First();
    }

    public void AddBullets(Weapon w, int count)
    {
        w.BulletsController.AddBullets(count);
        SetBestWeapon();
    }
}