using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShooter : MonoBehaviour, IShooter
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _spread;

    public void Shoot(float bulletSpeed, float damage, float range)
    {
        var rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-_spread / 2, _spread / 2));
        var bullet = Instantiate(_bulletPrefab, transform.position, rotation);
        bullet.SetStats(bulletSpeed, damage, range / bulletSpeed);
    }
}
