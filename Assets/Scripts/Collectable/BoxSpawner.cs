using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private DropBox _box;
    [SerializeField] private float _ySpawn = 2.5f, _xLeft = -22.5f, _xRight = 22.5f;

    private float spawnCoolDown;
    private BoxUpdate update;

    private void Start()
    {
        SpawnBox();
    }

    public void SetValues(BoxUpdate update)
    {
        spawnCoolDown = update.SpawnCoolDown;
        this.update = update;
    }

    private void SpawnBox()
    {
        var spawnPoint = new Vector2(GetRandomXCoordinate(), _ySpawn);
        var box = Instantiate(_box, transform);
        box.SetValues(update);
        box.SetTargetAndSetSpawnPoint(spawnPoint);
        StartCoroutine(SpawnCooldown());
    }

    private float GetRandomXCoordinate()
    {
        return Random.Range(_xLeft, _xRight);
    }

    private IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(spawnCoolDown);
        SpawnBox();
    }
}
