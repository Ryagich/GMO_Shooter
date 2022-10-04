using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossMovementController))]
public class EnemyCharger : MonoBehaviour
{
    public event Action OnComplete;

    [SerializeField] private float _chargeSpeed = 0.03f;

    private ITargetSetter targetSetter;
    private GameObject hero;

    private void Awake()
    {
        targetSetter = GetComponent<ITargetSetter>();
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    public void Charge()
    {
        targetSetter.SetTarget(hero.transform.position.x);
    }
}
