using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : MonoBehaviour
{
    private ITargetSetter targetSetter;
    private Transform hero;

    private void Awake()
    {
        targetSetter = GetComponent<ITargetSetter>();
        hero = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Charge()
    {
        targetSetter.SetTarget(hero.position.x);
    }
}
