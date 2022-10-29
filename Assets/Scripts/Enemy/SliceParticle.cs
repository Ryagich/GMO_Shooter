using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceParticle : MonoBehaviour
{
    private Vector2 speed;
    private float rotationSpeed;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1000;
        var range = 3;
        speed = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
        rotationSpeed = Random.Range(-range, range);
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.position += (Vector3)speed * Time.deltaTime;
        speed.y -= 6 * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime * 40));
    }
}
