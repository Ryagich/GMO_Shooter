using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private int hp;
    private float lifetime;

    private void Start()
    {
        hp = GetComponent<Collectable>().GetItemValue();
        lifetime = GetComponent<Collectable>().GetLifetime();
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    public int GetHp()
    {
        StopCoroutine(nameof(DestroyAfterTime));
        Destroy(gameObject);
        return hp;
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
