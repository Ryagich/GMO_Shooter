using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private int _baseCountBullets = 10;
    [SerializeField] private int _rangeCount = 2;
    [SerializeField] private float _spread = 1.0f;

    public override void Shoot()
    {
        var countBullets = _baseCountBullets + Random.Range(-_rangeCount, _rangeCount);
        for (int i = 0; i < countBullets; i++)
        {
            var addedOffset = Random.Range(0, countBullets) * Random.Range(-_spread, _spread);            
            var newRotation = _shootPoint.rotation * Quaternion.Euler(0, 0, addedOffset);
            var bullet = Instantiate(_bullet, _shootPoint.position, newRotation);
            bullet.SetStats(_speed, Damage, _time, mask);
        }
        inpulse.GenerateImpulse();

        isReady = false;
        BulletsController.SubtractBullets(1);
        Camera.main.GetComponent<MonoBehaviour>().StartCoroutine(CoolDown());//костыль
    }
}
