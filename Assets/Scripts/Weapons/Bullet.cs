using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TouchDamager))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetStats(float speed, float damage, float time)
    {
        this.speed = speed;
        StartCoroutine(DestroySelf(time));
        GetComponent<TouchDamager>().SetDamage(damage);
    }

    private IEnumerator DestroySelf(float delay)
    {
        yield return new WaitForSeconds(delay);
        //pool
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = speed * transform.right;
    }
}
