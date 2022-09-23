using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1, _xBound = 9.5f, _downBound = -.8f, topBound = 5.4f,
                                   _range = 2.0f;
    private Vector2 point;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point,
                                                                     _speed * Time.deltaTime);
        if (point.Equals(transform.position))
            point = new Vector2(GetXCoordinate(point.x), GetYCoordinate(point.y));
    }

    private float GetXCoordinate(float coordinate)
    {
        var random = Random.Range(coordinate - _range, coordinate + _range);
        return -_xBound <= random && random <= _xBound ? random : GetXCoordinate(coordinate);//Mathf.Clamp(random, -_xBound, _xBound);//
    }

    private float GetYCoordinate(float coordinate)
    {
        var random = Random.Range(coordinate - _range, coordinate + _range);
        return _downBound <= random && random <= topBound ? random : GetYCoordinate(coordinate);
    }
}
