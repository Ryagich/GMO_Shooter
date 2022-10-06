using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletsController : MonoBehaviour
{
    public event Action<int> OnBulletCountUpdated;
    public event Action OnOutOfBullets;
    public int CurrentCount { get => _currentCount; }
    public int MaxCount { get => _maxCount; }

    [SerializeField] private int _currentCount;
    [SerializeField] private int _maxCount;
    [SerializeField] private bool isInfinite;

    public bool HasBullets => CurrentCount > 0 || isInfinite;

    public void AddBullets(int value)
    {
        if (isInfinite)
            return;
        _currentCount = Math.Min(_currentCount + value, _maxCount);
        OnBulletCountUpdated.Invoke(CurrentCount);
    }

    public void SubtractBullets(int value)
    {
        if (isInfinite)
            return;
        _currentCount = Math.Max(0, _currentCount - value);
        OnBulletCountUpdated?.Invoke(_currentCount);
        if (_currentCount <= 0)
            OnOutOfBullets?.Invoke();
    }
}
