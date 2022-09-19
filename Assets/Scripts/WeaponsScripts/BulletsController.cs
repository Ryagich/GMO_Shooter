using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletsController
{
    public readonly UnityEvent<int> OnBulletCountUpdated = new UnityEvent<int>();
    public readonly UnityEvent<bool> OnHaveBullets = new UnityEvent<bool>();

    public int CurrentCount { get; private set; }
    private int maxCount;

    public bool HasBullets => CurrentCount > 0;

    public BulletsController(int currentCount, int maxCount)
    {
        CurrentCount = currentCount;
        this.maxCount = maxCount;
    }

    public void AddBullets(int value)
    {
        CurrentCount = CurrentCount + value >= maxCount 
                     ? maxCount : CurrentCount + value;
        OnBulletCountUpdated.Invoke(CurrentCount);
    }

    public void SubtractBullets(int value)
    {
        CurrentCount -= CurrentCount - value >= 0 ? value : CurrentCount;
        OnBulletCountUpdated.Invoke(CurrentCount);
        OnHaveBullets.Invoke(CurrentCount > 0);
    }
}
