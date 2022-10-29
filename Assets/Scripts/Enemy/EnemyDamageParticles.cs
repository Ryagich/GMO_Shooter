using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;


public class EnemyDamageParticles : MonoBehaviour
{
    private ParticleSystem particles;
    private ParticleSystem.ShapeModule shapeMode;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        shapeMode = particles.shape;
    }

    private void EmitBlood(Collider2D collider)
    {
        if (!collider.gameObject.TryGetComponent(out TouchDamager td))
            return;
        var angle = Vector3.Angle(collider.transform.position, transform.position);
        shapeMode.rotation = new Vector3(180 + angle, -90, 0);
        var pos = collider.transform.position - transform.position;
        pos.x /= transform.lossyScale.x;
        pos.y /= transform.lossyScale.y;
        pos.z /= transform.lossyScale.z;
        shapeMode.position = pos;
        particles.Stop();
        particles.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EmitBlood(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EmitBlood(collider);
    }
}
