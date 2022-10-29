using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Updates")]
public class Updates : ScriptableObject
{
    public BoxUpdate HpUpdates;
    public BoxUpdate CoinUpdates;
    public BoxUpdate RifleUpdates;
    public BoxUpdate ShotgunUpdates;
    public BoxUpdate ExplosionUpdates;

    public StatUpdate HpStatUpdates;
    public StatUpdate SpeedStatUpdates;
}

