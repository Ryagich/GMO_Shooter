using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptableLoader
{
    private const string WeaponsPath = @"Scriptable/Weapons";
    

    private const string UpdatesPath = @"Scriptable/Updates";
    public static readonly WeaponInfo[] WeaponsInfo;
    public static readonly StatUpdate[] StatUpdates;
    public static readonly BoxUpdate[] BoxUpdates;


    static ScriptableLoader()
    {
        WeaponsInfo = Resources.LoadAll<WeaponInfo>(WeaponsPath);
        StatUpdates = Resources.LoadAll<StatUpdate>(UpdatesPath);
        BoxUpdates = Resources.LoadAll<BoxUpdate>(UpdatesPath);
    }

    public static Weapon GetWeapon(int index) => WeaponsInfo[index].Weapon;
    public static StatUpdate GetStatUpdate(int index) => StatUpdates[index];
    public static BoxUpdate GetBoxUpdate(int index) => BoxUpdates[index];

    public static int FindWeapon(Weapon weapon) => Array.FindIndex(WeaponsInfo, wi => wi.Weapon.name == weapon.name);
    public static int FindStatUpdate(StatUpdate update) => Array.FindIndex(StatUpdates, su => su.name == update.name);
    public static int FindBoxUpdate(BoxUpdate update) => Array.FindIndex(BoxUpdates, bu => bu.name == update.name);
}
