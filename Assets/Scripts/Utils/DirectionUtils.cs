using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionUtils
{
    public static bool IsUp(float dir)
    {
        return dir > 45 && dir <= 135;
    }

    public static bool IsDown(float dir)
    {
        return dir > 225 && dir <= 315;
    }

    public static bool IsLeft(float dir)
    {
        return dir > 135 && dir <= 225;
    }

    public static bool IsRight(float dir)
    {
        return dir > 315 || dir <= 45;
    }
}
