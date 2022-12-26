using Newtonsoft.Json.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxSpawnerManager : MonoBehaviour
{
    [SerializeField] BoxSpawner _hp;
    [SerializeField] BoxSpawner _gold;
    [SerializeField] BoxSpawner _rifle;
    [SerializeField] BoxSpawner _shotgun;
    [SerializeField] BoxSpawner _tnt;

    public void Awake()
    {
        var s = SaveSystem.SaveManager.GetInstance();               
        var box = s.AvailableBoxUpdates;
        _hp.SetValues(box.Where(u => u.Type == BoxUpdateType.Hp).First());
        _gold.SetValues(box.Where(u => u.Type == BoxUpdateType.Gold).First());
        _rifle.SetValues(box.Where(u => u.Type == BoxUpdateType.Rifle).First());
        _shotgun.SetValues(box.Where(u => u.Type == BoxUpdateType.Shotgun).First());
        _tnt.SetValues(box.Where(u => u.Type == BoxUpdateType.Tnt).First());
    }
}
