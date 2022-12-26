using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdate
{
    public bool IsOpen { get; set; }

    public int Cost { get; set; }

    public ScriptableObject ScriptableObject { get; }
}
