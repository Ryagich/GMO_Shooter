using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public event Action<float> OnDamage;
    public bool CanTakeDamage = true;

    public void TakeDamage(float damage)
    {
        if (CanTakeDamage)
            OnDamage?.Invoke(damage);
    }
}
