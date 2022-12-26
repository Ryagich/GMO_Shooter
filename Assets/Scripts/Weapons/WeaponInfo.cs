using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo")]
public class WeaponInfo : ScriptableObject, ISaveId
{
    public Weapon Weapon;
    public Sprite WeaponSprite;
    public WeaponType WeaponType;
    public int Cost;
    public bool IsOpen = false;

    public string Id => name;
}

public enum WeaponType
{
    Pistol,
    Rifle,
    Shotgun,
}