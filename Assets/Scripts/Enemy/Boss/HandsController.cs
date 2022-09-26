using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    [SerializeField] private Transform _handsPoint;
    [SerializeField] private GameObject _handPref;
    [SerializeField] private int DefaultHandsCount;
    [SerializeField] private Collider2D _area;

    private int CurrHandsCount;

    private void Awake()
    {
        for (int i = 0; i < DefaultHandsCount; i++)
        {
            InstantiateHand();
        }
    }

    public void InstantiateHand()
    {
        var hand = Instantiate(_handPref, _handsPoint);
        CurrHandsCount++;
        hand.GetComponent<HandMovementController>().SetArea(_area);
    }

    private void DeleteHand()
    {
        CurrHandsCount--;
        Debug.Log("Рука потеряна! Текущее количество рук: " + CurrHandsCount);
    }
}
