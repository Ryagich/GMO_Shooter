using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public GameObject EnemyPrefab { get => _enemyPrefab; }

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _duration;

    private int _spawned = 0;

    public IEnumerator GetCorutine(EnemySpawner spawner)
    {
        _spawned = 0;
        while (_spawned < _enemyCount)
        {
            yield return new WaitForSeconds(_duration / _enemyCount);
            _spawned++;
            if (_spawned == _enemyCount / 2)
                spawner.NextWave();
            spawner.Spawn(_enemyPrefab);
        }
    }

}
