using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int itemValue;
    private float lifetime;

    public void SetValues(BoxUpdate update)
    {
        lifetime = update.ItemLifetime;
        itemValue = update.ItemValue;
    }

    public int GetItemValue() => itemValue;
    public float GetLifetime() => lifetime;
}
