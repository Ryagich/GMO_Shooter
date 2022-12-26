using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtentions
{
    public static void SetPosition2D(this Transform transform, Vector2 pos) =>
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    public static void SetRotation2D(this Transform transform, float angle)
    {
        var old = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(old.x, old.y, angle);
    }

    public static void SetLocalPosition2D(this Transform transform, Vector2 pos, float z = float.PositiveInfinity) =>
        transform.localPosition = new Vector3(pos.x, pos.y, z == float.PositiveInfinity ? transform.position.z : z);
    public static void SetLocalRotation2D(this Transform transform, float angle)
    {
        var old = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(old.x, old.y, angle);
    }
}
