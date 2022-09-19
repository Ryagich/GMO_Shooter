using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxUpdater : Updater
{
    [SerializeField] private BoxUpdate[] _boxUpdates;

    public BoxUpdate GetUpdate() => (BoxUpdate)_updates[index];

    protected override IUpdate[] GetUpdates() => _boxUpdates;
}
