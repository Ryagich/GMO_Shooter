using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHolder : MonoBehaviour
{
    public static MonoBehaviour Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
