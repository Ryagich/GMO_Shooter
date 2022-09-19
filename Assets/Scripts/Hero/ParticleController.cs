using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        EnableParticalSystem(Input.GetAxis("Horizontal") != 0);
    }

    public void EnableParticalSystem(bool enable)
    {
        particle.enableEmission = enable;
    }
}
