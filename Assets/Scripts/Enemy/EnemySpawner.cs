using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _leftPoint,
                                       _rightPoint;
    [SerializeField] private List<EnemyWave> _enemyWaves;

    private int waveIndex = 0;

    public void Start()
    {     
        NextWave();   
    }

    public void Spawn(GameObject prefab)
    {
        for (int i = 0; i < waveIndex; i++)
        {
            if (waveIndex < _enemyWaves.Count && Random.value > 0.8)
                CreateEnemy(_enemyWaves[waveIndex].EnemyPrefab);
        }
        CreateEnemy(prefab);
    }

    public void CreateEnemy(GameObject prefab)
    {
        var enemy = Instantiate(prefab, transform);
        enemy.transform.position = (Random.value > 0.5 ? _leftPoint : _rightPoint).position;
        enemy.transform.localScale *= Random.Range(0.8f, 1f);
    }

    public void NextWave()
    {   
        if (waveIndex < _enemyWaves.Count)
            StartCoroutine(_enemyWaves[waveIndex].GetCorutine(this));
        waveIndex++;
    }
}
