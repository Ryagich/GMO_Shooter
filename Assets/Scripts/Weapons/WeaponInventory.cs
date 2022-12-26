using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using SaveSystem;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
[RequireComponent(typeof(BulletsShower))]
public class WeaponInventory : MonoBehaviour
{
    public Weapon Pistol { get; private set; }
    public Weapon Rifle { get; private set; }
    public Weapon ShotGun { get; private set; }
    public Weapon ActiveWeapon { get; private set; }

    [SerializeField] private Transform _weaponsTransform;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private CinemachineImpulseSource _impulseSource;

    private List<Weapon> weapons;

    private void Awake()
    {
        weapons = new List<Weapon>();
        CreateWeapons();
        SetActiveWeapon(Pistol);
    }

    private void CreateWeapons()
    {
        var save = SaveManager.GetInstance();
        save.Save();
        save.Load();

        Pistol = CreateWeapon(save.SelectedPistol.Weapon);
        Rifle = CreateWeapon(save.SelectedRifle.Weapon);
        ShotGun = CreateWeapon(save.SelectedShotgun.Weapon);
        weapons.Sort((a, b) => b.DPS.CompareTo(a.DPS));
    }

    private Weapon CreateWeapon(Weapon weaponPrefab)
    {
        var w = Instantiate(weaponPrefab, _weaponsTransform);
        w.Init(_lineRenderer, _impulseSource);
        weapons.Add(w);
        w.BulletsController.OnOutOfBullets += SetBestWeapon;
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
        SetActiveWeapon(w);
        w.BulletsController.AddBullets(count);        
        //SetBestWeapon();
    }
}