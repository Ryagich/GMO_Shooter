using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ParticleController : MonoBehaviour
{
    [SerializeField] private float _rateMultiplier;
    private ParticleSystem particle;
    private Rigidbody2D rb;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var e = particle.emission;
        e.rateOverTimeMultiplier = Mathf.Abs(rb.velocity.x) * _rateMultiplier;
    }
}
