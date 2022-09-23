using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChanger : MonoBehaviour
{
    public static event Action OnEnemyChange;

    public float Time = 10.0f;

    private void Awake()
    {
        StartCoroutine(TimeEventTrigger());
    }

    private IEnumerator TimeEventTrigger()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time);
            OnEnemyChange?.Invoke();
        }
    }
}
