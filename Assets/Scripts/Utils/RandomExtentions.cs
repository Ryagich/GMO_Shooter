using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomExtentions
{
    public static Vector2 InBounds(Bounds bounds)
    {
        var min = bounds.min;
        var max = bounds.max;
        return new Vector2(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y)
            );
    }
}

