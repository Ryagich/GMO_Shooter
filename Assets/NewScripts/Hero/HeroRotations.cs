using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroRotations : MonoBehaviour
{
    [SerializeField] private Transform _body, _hands;

    private void Update()
    {
        var dir = InputHandler.Direction;
        var scaleSign = (dir > 90 || dir < -90) ? -1 : 1;

        _hands.SetRotation2D(dir);

        SetScaleSign(_body, scaleSign, 1);
        SetScaleSign(_hands, 1, scaleSign);
    }

    private void SetScaleSign(Transform target, float x, float y)
    {
        if (x != 0)
        {
            var sx = Mathf.Abs(target.localScale.x) * Mathf.Sign(x);
            target.localScale = target.localScale.WithX(sx);
        }
        if (y != 0)
        {
            var sy = Mathf.Abs(target.localScale.y) * Mathf.Sign(y);
            target.localScale = target.localScale.WithY(sy);
        }
    }
}
