using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatesReader : MonoBehaviour
{
    [SerializeField] private BoxSpawner _hpDropBoxSpawner;
    [SerializeField] private BoxSpawner _goldenDropBoxSpawner;
    [SerializeField] private BoxSpawner _rifleDropBoxSpawner;
    [SerializeField] private BoxSpawner _shotGunDropBoxSpawner;

    private void Awake()
    {
        var data = PlayerPrefsWrapper.LoadPrefs();
        _hpDropBoxSpawner.SetValues(data.HpBoxUpdate);
        _goldenDropBoxSpawner.SetValues(data.GoldenBoxUpdate);
        _rifleDropBoxSpawner.SetValues(data.RifleBoxUpdate);
        _shotGunDropBoxSpawner.SetValues(data.ShotGunBoxUpdate);        
    }
}
