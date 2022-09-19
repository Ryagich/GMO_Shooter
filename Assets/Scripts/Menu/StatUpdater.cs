using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUpdater : Updater
{
    [SerializeField] protected StatUpdate[] _statUpdates;

    public StatUpdate GetUpdate() => (StatUpdate)_updates[index]; 
    protected override IUpdate[] GetUpdates() => _statUpdates;
}
