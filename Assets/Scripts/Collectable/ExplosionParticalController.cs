using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticalController : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
