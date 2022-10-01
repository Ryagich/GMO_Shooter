using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableParticleController : MonoBehaviour
{
    [SerializeField] private float _treshold = 0.01f;

    private ParticleSystem particle;
    private Rigidbody2D rb;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var emission = particle.emission;
        emission.enabled = rb.velocity.SqrMagnitude() > _treshold;
    }
}
