using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    [SerializeField] private bool _useMobileInput;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _offset = 0.0f;

    private float rotation;

    private void Update()
    {   
        if (_useMobileInput && _joystick != null)
        {
            if (_joystick.Power > 0.01)
                rotation = _joystick.Direction;
        }
        else
        {
            var diference = Camera.main.ScreenToWorldPoint(Input.mousePosition)
                      - transform.position;
            rotation = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        }
        
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation + _offset);

        var localScale = transform.localScale;
        localScale.y = Mathf.Abs(localScale.y)
            * (rotation > 90 || rotation < -90 ? -1.0f : 1.0f);
        transform.localScale = localScale;
    }
}
