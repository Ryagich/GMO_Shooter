using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SoundPlayer))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _startScale;
    [SerializeField] private float _endScale;
    [SerializeField] private float _duration;
    [SerializeField] private float _power;
    [SerializeField] private float _damage;

    private float startTime;
    private HashSet<GameObject> damaged;

    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        transform.localScale = Vector3.one * _startScale;
        startTime = Time.time;
        damaged = new HashSet<GameObject>();
        var sp = GetComponent<SoundPlayer>();
        sp.Play();
    }

    private void FixedUpdate()
    {
        var f = (Time.time - startTime) / _duration;
        transform.localScale = Vector3.one * Mathf.Lerp(_startScale, _endScale, f);
        if (f > 1)
            Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var go = collision.gameObject;
        var damageable = go.GetComponent<Damageable>();
        if (!damageable)
            return;

        if (!damaged.Contains(go))
        {
            damaged.Add(go);
            damageable.TakeDamage(_damage);
            var rb = go.GetComponent<Rigidbody2D>();
            if (rb)
            {
                var d = go.transform.position - transform.position;
                var force = d.normalized * _power;
                rb.AddForce(force);
            }
        }
    }
}
