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
        _hpDropBoxSpawner.SetValues(Data.HpBoxUpdate);
        _goldenDropBoxSpawner.SetValues(Data.GoldenBoxUpdate);
        _rifleDropBoxSpawner.SetValues(Data.RifleBoxUpdate);
        _shotGunDropBoxSpawner.SetValues(Data.ShotGunBoxUpdate);        
    }
}
