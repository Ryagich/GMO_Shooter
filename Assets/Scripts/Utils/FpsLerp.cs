using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FpsLerp
{
    public static float Lerp(float a, float b, float f, float dTime) => 
        Mathf.Lerp(a, b, 1 - Mathf.Pow(f, dTime));
    
}