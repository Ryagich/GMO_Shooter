using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int Value { get => itemValue; }

    private int itemValue;
    private float lifetime;

    public Type CollectableType;

    private SoundPlayer player;

    private void Start()
    {
        player = GetComponent<SoundPlayer>();
    }

    public void SetValues(BoxUpdate update)
    {
        lifetime = update.ItemLifetime;
        itemValue = update.ItemValue;
        Destroy(gameObject, lifetime);
    }

    public void Collect()
    {
        if (player)
            player.Play();
        Destroy(gameObject);
    }


    public enum Type
    {
        Heart, Coin, ShotGunBullets, RifleBullets, Explosion
    }
}
