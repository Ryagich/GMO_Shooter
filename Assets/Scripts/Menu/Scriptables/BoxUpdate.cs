using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxUpdate")]
public class BoxUpdate : ScriptableObject, IUpdate
{
    public float SpawnCoolDown;
    public float BoxLifetime;
    public float ItemLifetime;
    public int ItemCount;
    public int ItemValue;
    public BoxUpdate NextUpdate;

    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public int Cost { get => _cost; set => _cost = value; }

    [SerializeField] private int _cost;
    [SerializeField] private bool _isOpen;
}
