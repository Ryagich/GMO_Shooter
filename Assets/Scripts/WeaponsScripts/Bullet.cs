using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Min(0.0f)] private float speed = 1.0f;
    [Min(0.0f)] private float damage = 5.0f;
    [Min(0.0f)] private float time = 1.0f;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyAfterTime(time));
    }

    public void SetStats(float speedV, float damageV, float time)
    {
        speed = speedV;
        damage = damageV;
        this.time = time;
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        rigidbody2D.velocity = transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null
        && !collision.gameObject.GetComponent<Enemy>().CanTakeDamage
         || collision.gameObject.GetComponent<DropBox>() != null
        && !collision.gameObject.GetComponent<DropBox>().CanBreak)
            return;
        collision.gameObject.GetComponent<Enemy>()?.TakeDamage(damage);
        collision.gameObject.GetComponent<DropBox>()?.Break();
        StopCoroutine("DestroyAfterTime");
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
