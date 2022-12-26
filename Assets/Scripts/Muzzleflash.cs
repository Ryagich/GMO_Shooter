using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Muzzleflash : MonoBehaviour
{
    [SerializeField] private Color _On, _Off;
    [SerializeField] private float _fadeSpeed = 25;

    private float state = 0;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Flash()
    {
        state = 1;
        transform.localScale = new Vector3(Random.Range(0.5f, 1), Random.Range(0.5f, 1), 1);
    }

    private void Update()
    {
        state = Mathf.MoveTowards(state, 0, Time.deltaTime * _fadeSpeed);
        sr.color = Color.Lerp(_Off, _On, state);
    }
}
