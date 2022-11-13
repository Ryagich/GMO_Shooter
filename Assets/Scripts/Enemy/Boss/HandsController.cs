using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    [SerializeField] private GameObject _normalHand, _smallHand;
    [SerializeField] private float _radius = 2f, _circleTime = 5f;
    [SerializeField] private int _defaultHandsCount, _smallHandsSpawnCount = 2;
    [SerializeField] private Collider2D _area;

    private List<GameObject> hands = new List<GameObject>();
    private Transform handsParent;
    private BossMovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<BossMovementController>();
        handsParent = new GameObject().transform;

        for (int i = 0; i < _defaultHandsCount; i++)
        {
            InstantiateBigHand();
        }
    }

    public void StartCircleHands()
    {
        StopCircle();
        if (hands == null || hands.Count == 0)
            return;
        movementController.IsCircle = true;
        var handAngle = (Mathf.PI * 2) / hands.Count;
        for (int i = 0; i < hands.Count; i++)
        {
            if (hands[i] != null)
                hands[i].GetComponent<HandMovementController>().StartCircle(_radius, handAngle * i, movementController.CirclePoint);
        }
        StartCoroutine(CircleTime());
    }

    public IEnumerator CircleTime()
    {
        yield return new WaitForSeconds(_circleTime);
        StopCircle();
    }

    private void StopCircle()
    {
        movementController.IsCircle = false;
        for (int i = 0; i < hands.Count; i++)
            if (hands[i] != null)
                hands[i].GetComponent<HandMovementController>().StopCircle();
    }

    public void InstantiateBigHand()
    {
        var hand = InstantiateHand(_normalHand);
        hand.GetComponent<EnemyHp>().OnDeath += CreateSmallHand;
    }

    private void CreateSmallHand()
    {
        for (int i = 0; i < _smallHandsSpawnCount; i++)
            InstantiateHand(_smallHand);
    }

    private GameObject InstantiateHand(GameObject handObj)
    {
        var hand = Instantiate(handObj, handsParent);
        hand.GetComponent<HandMovementController>().SetArea(_area);
        hand.GetComponent<EnemyHp>().OnDeath += DeleteHand;
        hands.Add(hand);

        return hand;
    }

    private void DeleteHand()
    {
        var e = from CHands in hands
                where CHands != null
                select CHands;
        hands = e.ToList();
    }
}
