using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{
    public bool CanBreak = true;

    [SerializeField] private Collectable _dropItem;
    [SerializeField] private float _yTarget = -1.0f;
    [SerializeField, Min(1.0f)] private float _explosion = 5.0f;
    [SerializeField, Min(1.0f)] private float _speed = 1.0f;
    [SerializeField] private float _distanceTreshold = 0.01f;
    [SerializeField] private ExplosionParticalController _explosionEffect;

    private int itemCount;
    private float lifeTime = 6;
    private Vector2 target = new Vector2();
    private BoxUpdate update;

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
            StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    public void Break()
    {
        Instantiate(_explosionEffect, transform.position,transform.rotation);
        CanBreak = false;        
        for (int i = 0; i < itemCount; i++)
        {
            
            var pref = Instantiate(_dropItem, transform.position,
                                              transform.rotation);
            pref.SetValues(update);
            pref.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-_explosion, _explosion),
                                                                                _explosion), ForceMode2D.Impulse); ;
        }
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
