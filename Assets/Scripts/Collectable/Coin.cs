using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int cost;
    private float lifetime;

    private void Start()
    {
        cost = GetComponent<Collectable>().GetItemValue();
        lifetime = GetComponent<Collectable>().GetLifetime();
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    public int GetCoins()
    {
        StopCoroutine(nameof(DestroyAfterTime));
        Destroy(gameObject);
        return cost;
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
