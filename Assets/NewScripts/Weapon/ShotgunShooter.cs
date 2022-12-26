using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShooter : MonoBehaviour, IShooter
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _bulletCount;    
    [SerializeField] private float _spread;

    public void Shoot(float bulletSpeed, float damage, float range)
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            var rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-_spread / 2, _spread / 2));
            var bullet = Instantiate(_bulletPrefab, transform.position, rotation);
            bullet.SetStats(bulletSpeed, damage / _bulletCount, range / bulletSpeed);
        }
    }
}
