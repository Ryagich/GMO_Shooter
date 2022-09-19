using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunDropBullet : MonoBehaviour
{
    private int countBullets;
    private float lifetime;

    private void Start()
    {
        countBullets = GetComponent<Collectable>().GetItemValue();
        lifetime = GetComponent<Collectable>().GetLifetime();
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    public int GetBullets()
    {
        StopCoroutine(nameof(DestroyAfterTime));
        Destroy(gameObject);
        return countBullets;
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
