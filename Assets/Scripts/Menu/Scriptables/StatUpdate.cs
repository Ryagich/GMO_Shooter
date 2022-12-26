using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatUpdate")]
public class StatUpdate : ScriptableObject, IUpdate, ISaveId
{
    public float Update;
    public StatUpdate NextUpdate;
    
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public int Cost { get => _cost; set => _cost = value; }

    public ScriptableObject ScriptableObject => this;

    public string Id => name;

    [SerializeField] private int _cost;
    [SerializeField] private bool _isOpen;
}
