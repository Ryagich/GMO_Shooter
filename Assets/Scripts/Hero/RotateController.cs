using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private bool _useMobileInput = true;
    [SerializeField] private Joystick _joystick;

    private float rotation;

    private void Update()
    {
        if (_useMobileInput && _joystick)
        {
            if (_joystick.Power > 0.01)
                rotation = _joystick.Direction;
        }
        else
        {
            var diference = Camera.main.ScreenToWorldPoint(Input.mousePosition)
                            - _transform.position;
            rotation = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        }

        var localScale = _transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) 
            * (rotation > 90 || rotation < -90 ? 1.0f : -1.0f);
        _transform.localScale = localScale;
    }
}
