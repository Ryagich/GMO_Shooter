using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FpsLerp
{
    public static float Lerp(float a, float b, float f, float dTime) =>
        Mathf.Lerp(a, b, 1f - Mathf.Pow(f, dTime));

    public static Vector2 Lerp(Vector2 a, Vector2 b, float f, float dTime) =>
        Vector2.Lerp(a, b, 1f - Mathf.Pow(f, dTime));

    public static Vector3 Lerp(Vector3 a, Vector3 b, float f, float dTime) =>
        Vector3.Lerp(a, b, 1f - Mathf.Pow(f, dTime));
}