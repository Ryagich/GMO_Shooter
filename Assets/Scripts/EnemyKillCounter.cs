using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillCounter : MonoBehaviour
{
    public static EnemyKillCounter Instance;

    public int count = 0;

    private void Awake()
    {
        Instance = this;
    }
}
