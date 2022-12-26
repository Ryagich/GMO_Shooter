using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private float _rateMultiplier;
    private ParticleSystem particle;
    private Vector3 lastPos;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        var e = particle.emission;
        e.rateOverTimeMultiplier = (lastPos - transform.position).magnitude * _rateMultiplier;
        lastPos = transform.position;
    }
}
