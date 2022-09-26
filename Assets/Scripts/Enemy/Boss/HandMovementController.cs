using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f, _range = 2.0f;
    private Collider2D area;
    private Vector2 target;

    public void SetArea(Collider2D area)
    {
        this.area = area;
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target,
                                                   _speed * Time.deltaTime);
        if (area == null)
            Debug.Log("Ghj,ktvf!!!");
        if (target.Equals(transform.position))
        {
            var x = area.bounds.center.x ;
            var yDown = area.bounds.min.y;
            var yTop = area.bounds.max.y;
            target = new Vector2(GetXCoordinate(target.x, x), GetYCoordinate(target.y, yDown, yTop));
        }
    }

    private float GetXCoordinate(float coordinate, float bound)
    {
        Debug.Log(bound * 2);
        var random = Random.Range(coordinate - _range, coordinate + _range);
        return -bound <= random && random <= bound ? random : GetXCoordinate(coordinate, bound);//Mathf.Clamp(random, -_xBound, _xBound);//
    }

    private float GetYCoordinate(float coordinate, float yDown, float yTop)
    {
        Debug.Log(yDown);
        Debug.Log(yTop);
        var random = Random.Range(Mathf.Min(yDown, yTop), Mathf.Max(yDown, yTop));
        return yDown <= random && random <= yTop ? random : GetYCoordinate(coordinate, yDown, yTop);
    }
}
