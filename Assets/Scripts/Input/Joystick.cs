using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    [SerializeField][Min(0)] public float Scale = 1;

    [Header("Images")]
    [SerializeField] private Image stick;
    [SerializeField] private Image background;    

    private RectTransform activeRect;

    private Vector2 startPoint;
    private Vector2 activePoint;

    private int finger;
    public bool IsPressed { get; private set; }
    public float Direction { get; private set; }
    public float Power { get; private set; }

    private void Start()
    {
        var img = GetComponent<Image>();
        if (img != null)
            img.enabled = false;
        activeRect = GetComponent<RectTransform>();
        MobileInput.OnDragBegin += OnDragBegin;
        MobileInput.OnDrag += OnDrag;
        MobileInput.OnDragEnd += OnDragEnd;
    }

    private void Update()
    {
        UpdateValues();
        UpdateInterface();
    }

    private void OnDestroy()
    {
        MobileInput.OnDragBegin -= OnDragBegin;
        MobileInput.OnDrag -= OnDrag;
        MobileInput.OnDragEnd -= OnDragEnd;
    }

    private void UpdateValues()
    {
        Power = Vector2.Distance(startPoint, activePoint);
        Power = Mathf.Clamp01(2 * Power / background.rectTransform.sizeDelta.x);
        Direction = Vector2.SignedAngle(Vector2.right, activePoint - startPoint);
    }

    private void UpdateInterface()
    {
        background.transform.localScale = Vector3.one * Scale;
        stick.transform.localScale = Vector3.one * Scale;

        background.enabled = IsPressed;
        stick.enabled = IsPressed;
        if (!IsPressed)
            return;
        background.transform.position = startPoint;
        var d = (activePoint - startPoint);
        var maxLength = background.rectTransform.sizeDelta.x
                      * background.rectTransform.lossyScale.x
                      * 0.5f;
        var norm = d.normalized * maxLength;
        if (d.sqrMagnitude > maxLength * maxLength)
            d = norm;
        stick.transform.position = startPoint + d;
    }

    private void OnDragBegin(GestureEvent args)
    {
        if (!BoundsUtils.IsInsideTransform(activeRect, args.Position))
            return;
        if (IsPressed)
            return;
        startPoint = args.Position;
        finger = args.Finger;
        IsPressed = true;
    }

    private void OnDrag(GestureEvent args)
    {
        if (!IsPressed)
            return;
        if (args.Finger != finger)
            return;
        activePoint = args.Position;
    }

    private void OnDragEnd(GestureEvent args)
    {
        if (!IsPressed)
            return;
        if (args.Finger != finger)
            return;
        IsPressed = false;
        activePoint = Vector2.zero;
        startPoint = Vector2.zero;
    }
}
