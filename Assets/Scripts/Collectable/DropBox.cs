using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class DropBox : MonoBehaviour
{
    [SerializeField] private Collectable _dropItem;
    [SerializeField] private float _yTarget = -1.0f;
    [SerializeField, Min(0)] private float _explosionForce = 5.0f;
    [SerializeField, Min(0)] private float _speed = 1.0f;
    [SerializeField] private float _distanceTreshold = 0.01f;
    [SerializeField] private ExplosionParticleController _explosionEffect;

    private int itemCount;
    private float lifeTime = 6;
    private Vector2 target = new Vector2();
    private BoxUpdate update;
    private Damageable damageble;

    private void Start()
    {
        damageble = GetComponent<Damageable>();
        damageble.OnDamage += Break;
    }

    public void SetValues(BoxUpdate update)
    {
        itemCount = update.ItemCount;
        lifeTime = update.BoxLifetime;
        this.update = update;
    }

    public void SetTargetAndSetSpawnPoint(Vector2 spawnPoint)
    {
        transform.position = spawnPoint;
        target = new Vector2(transform.position.x, _yTarget);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            target, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < _distanceTreshold)
            Destroy(gameObject, lifeTime);
    }

    public void Break(float _)
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        damageble.CanTakeDamage = false;
        for (int i = 0; i < itemCount; i++)
        {
            var pref = Instantiate(_dropItem, transform.position,
                                              transform.rotation);
            pref.SetValues(update);
            var impulse = new Vector2(Random.Range(-_explosionForce, _explosionForce), _explosionForce);
            pref.GetComponent<Rigidbody2D>()
                .AddForce(impulse, ForceMode2D.Impulse);
        }
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
