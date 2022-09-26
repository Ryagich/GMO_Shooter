using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f, _range = 2.0f;
    [SerializeField] private Collider2D _area;

    private float xBound, yTopBound,yDownBound;
    private Vector2 target;

    private void Awake()
    {
        xBound = _area.bounds.size.x / 2;
        yTopBound = _area.bounds.size.y / 2 + _area.gameObject.transform.position.y;
        yDownBound = _area.bounds.size.y / 2 - _area.gameObject.transform.position.y;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target,
                                                   _speed * Time.deltaTime);
        if (target.Equals(transform.position))
            target = new Vector2(GetXCoordinate(target.x), GetYCoordinate(target.y));
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    private float GetXCoordinate(float coordinate)
    {
        var random = Random.Range(coordinate - _range, coordinate + _range);
        return -xBound <= random && random <= xBound ? random : GetXCoordinate(coordinate);//Mathf.Clamp(random, -_xBound, _xBound);//
    }

    private float GetYCoordinate(float coordinate)
    {
        var random = Random.Range(coordinate - _range, coordinate + _range);
        return yDownBound <= random && random <= yTopBound ? random : GetYCoordinate(coordinate);
    }
}
