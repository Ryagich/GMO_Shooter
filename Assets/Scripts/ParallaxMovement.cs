using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;
    [SerializeField] private List<Transform> _layers;
    [SerializeField] private Transform _follow;

    private float oldX;

    private void Start()
    {
        oldX = _follow.position.x;
    }

    private void Update()
    {
        var d = oldX - _follow.position.x;
        for (int i = 0; i < _layers.Count; i++)
        {
            var moveX = (-d * _speed * 0.5f) / (1 + _layers.Count - i);
            _layers[i].transform.position += new Vector3(moveX, 0, 0);
        }
        oldX = _follow.position.x;
    }
}
