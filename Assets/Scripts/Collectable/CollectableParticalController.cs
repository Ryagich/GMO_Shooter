using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableParticalController : MonoBehaviour
{
    [SerializeField] private float _treshold = 0.01f;

    private ParticleSystem particle;
    private Rigidbody2D rb;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        EnableParticalSystem(rb.velocity.SqrMagnitude() > _treshold);
    }

    public void EnableParticalSystem(bool enable)
    {
        particle.enableEmission = enable;
    }
}
