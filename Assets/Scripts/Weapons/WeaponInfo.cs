using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    public Weapon Weapon;
    public Sprite WeaponSprite;
    public int Cost;
    public bool IsOpen = false;
}
