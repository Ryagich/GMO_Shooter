using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtentions
{
    public static T Last<T>(this List<T> l) => l[l.Count - 1];
}
