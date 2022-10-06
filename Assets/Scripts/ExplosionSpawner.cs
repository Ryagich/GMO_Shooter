using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var exp = Instantiate(_explosion);
            exp.transform.position = transform.position;
        }   
    }
}
