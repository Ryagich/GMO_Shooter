using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    [SerializeField] private Lazer _lazer;
    [SerializeField] private Collider2D _area;

    private Bounds bounds;
    private Transform hero;


    private void Awake()
    {
        bounds = _area.bounds;
        hero = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnInRandomPlace()
    {
        var lazer = Instantiate(_lazer);
        lazer.transform.position = new Vector2(Random.Range(-bounds.size.x / 2, bounds.size.x / 2), lazer.transform.position.y);
    }

    public void SpawnOnHero()
    {
        var lazer = Instantiate(_lazer);
        lazer.transform.position = new Vector2(hero.position.x, lazer.transform.position.y);
    }
}
