using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatesSaver : MonoBehaviour
{
    [SerializeField] private StatUpdater _hpUpdater;
    [SerializeField] private StatUpdater _speedUpdater;
    [SerializeField] private BoxUpdater _rifleBoxUpdater;
    [SerializeField] private BoxUpdater _shotGunBoxUpdater;
    [SerializeField] private BoxUpdater _goldenBoxUpdater;
    [SerializeField] private BoxUpdater _hpBoxUpdater;

    public void SaveStatUpdates()
    {
        Data.HpUpdate = _hpUpdater.GetUpdate();
        Data.SpeedUpdate = _speedUpdater.GetUpdate();
    }

    public void SaveBoxUpdates()
    {
        Data.RifleBoxUpdate = _rifleBoxUpdater.GetUpdate();
        Data.ShotGunBoxUpdate = _shotGunBoxUpdater.GetUpdate();
        Data.GoldenBoxUpdate = _goldenBoxUpdater.GetUpdate();
        Data.HpBoxUpdate = _hpBoxUpdater.GetUpdate();
    }
}
