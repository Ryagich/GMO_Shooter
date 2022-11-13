using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _warning;
    [SerializeField] private GameObject _lazer;

    [SerializeField] private int _warningFlashing = 5;
    [SerializeField] private int _lazerFlashing = 3;
    [SerializeField] private float _flashingTime = .1f;
    [SerializeField] private float _warningTime = 2f;

    private void Start()
    {
        _lazer.SetActive(false);
        _warning.gameObject.SetActive(false);

        StartCoroutine(Animate());
    }
	
	private void FixedUpdate() {
		if (Random.Range(0, 100) > 50) {
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

    private IEnumerator Animate()
    {
        _warning.gameObject.SetActive(true);

        for (int i = 0; i < 255; i++)
        {
            yield return new WaitForSeconds(0.001f);
            var color = _warning.color;
            color.a = i / 255f;
            _warning.color = color;
        }
        yield return new WaitForSeconds(_warningTime);

        for (int i = 0; i < _warningFlashing; i++)
        {
            yield return new WaitForSeconds(_flashingTime);
            _warning.gameObject.SetActive(!_warning.gameObject.activeSelf);
        }
        for (int i = 0; i < _lazerFlashing; i++)
        {
            yield return new WaitForSeconds(_flashingTime);
            _lazer.SetActive(!_lazer.activeSelf);
        }

        Destroy(gameObject);
    }
}
