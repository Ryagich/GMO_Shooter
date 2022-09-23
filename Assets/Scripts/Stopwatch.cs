using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public static Stopwatch Instance;

    private float startTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startTime = Time.time;
    }

    public float GetTime() => Time.time - startTime;
}
