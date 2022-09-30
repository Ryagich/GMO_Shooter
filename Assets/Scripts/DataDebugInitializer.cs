using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDebugInitializer : MonoBehaviour
{
#if UNITY_EDITOR
    public bool DEBUG = true;

    public Weapon SelectedPistol;
    public Weapon SelectedRifle;
    public Weapon SelectedShotGun;
    public int CurrentCash = 500;
    public StatUpdate HpUpdate;
    public StatUpdate SpeedUpdate;
    public BoxUpdate RifleBoxUpdate;
    public BoxUpdate ShotGunBoxUpdate;
    public BoxUpdate GoldenBoxUpdate;
    public BoxUpdate HpBoxUpdate;
    public int DescentsCount = 0;

    private void Start()
    {
        Data.SelectedPistol = SelectedPistol;
        Data.SelectedRifle = SelectedRifle;
        Data.SelectedShotGun = SelectedShotGun;
        Data.CurrentCash = CurrentCash;
        Data.HpUpdate = HpUpdate;
        Data.SpeedUpdate = SpeedUpdate;
        Data.RifleBoxUpdate = RifleBoxUpdate;
        Data.ShotGunBoxUpdate = ShotGunBoxUpdate;
        Data.GoldenBoxUpdate = GoldenBoxUpdate;
        Data.HpBoxUpdate = HpBoxUpdate;
        Data.DescentsCount = DescentsCount;
    }
#endif
}
