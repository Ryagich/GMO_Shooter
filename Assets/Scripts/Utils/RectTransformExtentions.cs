using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectTransformExtensions
{
    public static void SetPadding(this RectTransform rect, float horizontal, float vertical)
    {
        rect.offsetMax = new Vector2(-horizontal, -vertical);
        rect.offsetMin = new Vector2(horizontal, vertical);
    }

    public static void SetPadding(this RectTransform rect, float left, float top, float right, float bottom)
    {
        rect.offsetMax = new Vector2(-right, -top);
        rect.offsetMin = new Vector2(left, bottom);
    }
}
