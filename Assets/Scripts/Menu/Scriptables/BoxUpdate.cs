using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxUpdate")]
public class BoxUpdate : ScriptableObject, IUpdate, ISaveId
{
    public float SpawnCoolDown;
    public float BoxLifetime;
    public float ItemLifetime;
    public int ItemCount;
    public int ItemValue;
    public BoxUpdate NextUpdate;
    public BoxUpdateType Type;

    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public int Cost { get => _cost; set => _cost = value; }

    public ScriptableObject ScriptableObject => this;

    public string Id => name;

    [SerializeField] private int _cost;
    [SerializeField] private bool _isOpen;
}

public enum BoxUpdateType
{
    Hp, Gold, Rifle, Shotgun, Tnt
}