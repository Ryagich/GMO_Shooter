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

    private BulletsShower bulletsShower;
    private CinemachineImpulseSource impulseSource;
    private List<Weapon> weapons;

    private void Awake()
    {
        bulletsShower = GetComponent<BulletsShower>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        weapons = new List<Weapon>();
    }

    private void Start()
    {
        CreateWeapons();
        SetActiveWeapon(Pistol);
    }

    private void CreateWeapons()
    {
        Pistol = CreateWeapon(Data.SelectedPistol);
        Rifle = CreateWeapon(Data.SelectedRifle);
        ShotGun = CreateWeapon(Data.SelectedShotGun);
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

    private void SetActiveWeapon(Weapon activeWeapon)
    {
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