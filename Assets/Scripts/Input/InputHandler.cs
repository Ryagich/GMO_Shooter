using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private HoverButton _left, _right;
    [SerializeField] private bool _useMobileInput;

    [HideInInspector] public static float Direction;
    [HideInInspector] public static bool IsDirectionUpdating;
    [HideInInspector] public static float Horizontal;

    private static InputHandler instance;

    private void Start()
    {
        if (instance != null)
            Debug.Log("More than one InputHandler!");
        instance = this;
    }

    private void Update()
    {
        UpdateHorizontal();
        UpdateDirection();
    }

    private void UpdateHorizontal()
    {   
        if (_useMobileInput && _left != null && _right != null)
        {
            Horizontal = 0;
            Horizontal -= _left.IsPressed ? 1 : 0;
            Horizontal += _right.IsPressed ? 1 : 0;
        }
        else
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
        }
    }

    private void UpdateDirection()
    {
        if (_useMobileInput && _joystick)
        {
            if (_joystick.Power > 0.01)
            {
                Direction = _joystick.Direction;
                IsDirectionUpdating = true;
            }
            else
            {
                IsDirectionUpdating = false;
            }
        }
        else
        {
            var diference = (Vector2)Input.mousePosition - Screen.safeArea.size / 2;
            Direction = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            IsDirectionUpdating = true;
        }
    }
}
