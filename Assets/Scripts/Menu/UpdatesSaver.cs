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
        var data = PlayerPrefsWrapper.LoadPrefs();
        data.HpUpdate = _hpUpdater.GetUpdate();
        data.SpeedUpdate = _speedUpdater.GetUpdate();
        PlayerPrefsWrapper.SavePrefs(data);
    }

    public void SaveBoxUpdates()
    {
        var data = PlayerPrefsWrapper.LoadPrefs();
        data.RifleBoxUpdate = _rifleBoxUpdater.GetUpdate();
        data.ShotGunBoxUpdate = _shotGunBoxUpdater.GetUpdate();
        data.GoldenBoxUpdate = _goldenBoxUpdater.GetUpdate();
        data.HpBoxUpdate = _hpBoxUpdater.GetUpdate();
        PlayerPrefsWrapper.SavePrefs(data);
    }
}
