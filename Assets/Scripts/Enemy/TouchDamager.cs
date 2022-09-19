using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamager : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _secondsBetweenAttacks = 1.0f;
    [SerializeField] [Min(0.0f)] private float _damage = 5.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
           StartCoroutine(WaitBetweenAttacks(collision));
    } 

    private IEnumerator WaitBetweenAttacks(Collider2D collision)
    {
        collision.GetComponent<Hero>()?.TakeDamage(_damage);
        yield return new WaitForSeconds(_secondsBetweenAttacks);
           StartCoroutine(WaitBetweenAttacks(collision));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines(); 
    }
}
