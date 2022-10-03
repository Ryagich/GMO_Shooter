using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static Weapon SelectedPistol;
    public static Weapon SelectedRifle;
    public static Weapon SelectedShotGun;

    public static int CurrentCash = 5000;

    public static StatUpdate HpUpdate;
    public static StatUpdate SpeedUpdate;
    public static BoxUpdate RifleBoxUpdate;
    public static BoxUpdate ShotGunBoxUpdate;
    public static BoxUpdate GoldenBoxUpdate;
    public static BoxUpdate HpBoxUpdate;

    public static int DescentsCount = 0;
}
