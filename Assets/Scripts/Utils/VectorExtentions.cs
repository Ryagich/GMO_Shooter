using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtentions
{
    public static Vector3 WithX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);
    public static Vector3 WithY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);
    public static Vector3 WithZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);

    public static Vector3 ScaledX(this Vector3 vector, float scale) => new Vector3(vector.x * scale, vector.y, vector.z);
    public static Vector3 ScaledY(this Vector3 vector, float scale) => new Vector3(vector.x, vector.y * scale, vector.z);
    public static Vector3 ScaledZ(this Vector3 vector, float scale) => new Vector3(vector.x, vector.y, vector.z * scale);

    public static Vector2 WithX(this Vector2 vector, float x) => new Vector2(x, vector.y);
    public static Vector2 WithY(this Vector2 vector, float y) => new Vector2(vector.x, y);
    public static Vector2 ScaledX(this Vector2 vector, float scale) => new Vector2(scale * vector.x, vector.y);
    public static Vector2 ScaledY(this Vector2 vector, float scale) => new Vector2(vector.x, scale * vector.y);
}