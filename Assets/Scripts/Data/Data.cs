using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public static Data GetDefault() => new Data();

    public Weapon SelectedPistol
    {
        get => ScriptableLoader.GetWeapon(_selectedPistol);
        set => _selectedPistol = ScriptableLoader.FindWeapon(value);
    }

    public Weapon SelectedRifle
    {
        get => ScriptableLoader.GetWeapon(_selectedRifle);
        set => _selectedRifle = ScriptableLoader.FindWeapon(value);
    }

    public Weapon SelectedShotGun
    {
        get => ScriptableLoader.GetWeapon(_selectedShotGun);
        set => _selectedShotGun = ScriptableLoader.FindWeapon(value);
    }

    public int CurrentCash
    {
        get => _currentCash;
        set => _currentCash = value;
    }

    public int MaxLevel
    {
        get => _maxLevel;
        set => _maxLevel = value;
    }

    public StatUpdate HpUpdate
    {
        get => ScriptableLoader.GetStatUpdate(_hpUpdate);
        set => _hpUpdate = ScriptableLoader.FindStatUpdate(value);
    }

    public StatUpdate SpeedUpdate
    {
        get => ScriptableLoader.GetStatUpdate(_speedUpdate);
        set => _speedUpdate = ScriptableLoader.FindStatUpdate(value);
    }

    public BoxUpdate RifleBoxUpdate
    {
        get => ScriptableLoader.GetBoxUpdate(_rifleBoxUpdate);
        set => _rifleBoxUpdate = ScriptableLoader.FindBoxUpdate(value);
    }

    public BoxUpdate ShotGunBoxUpdate
    {
        get => ScriptableLoader.GetBoxUpdate(_shotGunBoxUpdate);
        set => _shotGunBoxUpdate = ScriptableLoader.FindBoxUpdate(value);
    }

    public BoxUpdate GoldenBoxUpdate
    {
        get => ScriptableLoader.GetBoxUpdate(_goldenBoxUpdate);
        set => _goldenBoxUpdate = ScriptableLoader.FindBoxUpdate(value);
    }

    public BoxUpdate HpBoxUpdate
    {
        get => ScriptableLoader.GetBoxUpdate(_hpBoxUpdate);
        set => _hpBoxUpdate = ScriptableLoader.FindBoxUpdate(value);
    }

    [SerializeField] private int _selectedPistol;
    [SerializeField] private int _selectedRifle;
    [SerializeField] private int _selectedShotGun;
    [SerializeField] private int _currentCash;
    [SerializeField] private int _maxLevel;
    [SerializeField] private int _hpUpdate;
    [SerializeField] private int _speedUpdate;
    [SerializeField] private int _rifleBoxUpdate;
    [SerializeField] private int _shotGunBoxUpdate;
    [SerializeField] private int _goldenBoxUpdate;
    [SerializeField] private int _hpBoxUpdate;
}