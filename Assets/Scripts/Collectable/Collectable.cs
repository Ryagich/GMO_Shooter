using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int Value { get => itemValue; }

    private int itemValue;
    private float lifetime;

    public Type CollectableType;

    public void SetValues(BoxUpdate update)
    {
        lifetime = update.ItemLifetime;
        itemValue = update.ItemValue;
        Destroy(gameObject, lifetime);
    }

    public enum Type
    {
        Heart, Coin, ShotGunBullets, RifleBullets
    }
}
