using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter
{
    public void Shoot(float bulletSpeed, float damage, float range);
}
