using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float CooldownTime = 1.0f;

    [SerializeField] private Transform _leftPoint, _rightPoint;
    [SerializeField] private List<GameObject> _enemies;

    private float randomOffset = 0.5f;
    private int enemyIndex = 0;

    private void Awake()
    {
        EnemyChanger.OnEnemyChange += ChooseEnemy;
        SpawnEnemy();
    }

    private void ChooseEnemy()
    {
        if (_enemies.Count <= enemyIndex + 1)
            return;
        enemyIndex++;
    }

    private void SpawnEnemy()
    {
        var spawnPoint = Random.Range(0, 1) > randomOffset
                                                        ? GetSpawnPoint(_rightPoint, true)
                                                        : GetSpawnPoint(_leftPoint, false);
        Instantiate(_enemies[enemyIndex], spawnPoint);
        StartCoroutine(SpawnCooldown(CooldownTime + Random.Range(-0.8f, 5.0f)));
    }

    private Transform GetSpawnPoint(Transform point, bool isRight)
    {
        randomOffset += isRight ? 0.1f : -0.1f;
        return point;
    }

    private IEnumerator SpawnCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        SpawnEnemy();
    }
}
