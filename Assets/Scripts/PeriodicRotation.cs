using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicRotation : MonoBehaviour
{
    [SerializeField] private float _speed, _amplitude;

    private void Update()
    {
        transform.Rotate(0, 0, Mathf.Sin(_speed * Time.time) * _amplitude * Time.deltaTime);
    }
}
