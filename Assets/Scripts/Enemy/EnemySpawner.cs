using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float CooldownTime = 1.0f;

    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Enemy _enemy;
    private float offset = 0.5f;
    private void Awake()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        var spawnPoint = Random.Range(0, 1) > offset ? GetSpawnPoint(_rightPoint, true)
                                                     : GetSpawnPoint(_leftPoint, false);
        Instantiate(_enemy, spawnPoint);
        StartCoroutine(SpawnCooldown(CooldownTime + Random.Range(-0.8f, 5.0f)));
    }

    private Transform GetSpawnPoint(Transform point, bool isRight)
    {
        offset += isRight ? 0.1f : -0.1f;
        return point;
    }

    private IEnumerator SpawnCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        SpawnEnemy();
    }
}
