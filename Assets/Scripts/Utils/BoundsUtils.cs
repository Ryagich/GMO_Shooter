using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoundsUtils
{
    public static Rect BoundsToRect(Bounds b)
    {
        return new Rect(b.min, b.max - b.min);
    }

    public static void DebugDrawRect(Rect r, Color c)
    {
        Debug.DrawLine(new Vector2(r.xMin, r.yMin), new Vector2(r.xMin, r.yMax), c);
        Debug.DrawLine(new Vector2(r.xMax, r.yMin), new Vector2(r.xMax, r.yMax), c);
        Debug.DrawLine(new Vector2(r.xMin, r.yMin), new Vector2(r.xMax, r.yMin), c);
        Debug.DrawLine(new Vector2(r.xMin, r.yMax), new Vector2(r.xMax, r.yMax), c);
    }

    public static Rect GetCameraViewRect2d(Camera cam)
    {
        var sz = cam.orthographicSize;
        var aspect = cam.aspect;
        var pos = cam.transform.position;
        var d = new Vector2(sz * aspect, sz);
        return new Rect((Vector2)pos - d, d * 2);
    }

    public static bool IsInsideTransform(RectTransform transform, Vector2 screenPos)
    {
        var pos = transform.InverseTransformPoint(screenPos);
        return pos.x < transform.rect.xMax &&
               pos.y < transform.rect.yMax &&
               pos.x > transform.rect.xMin &&
               pos.y > transform.rect.yMin;
    }
}