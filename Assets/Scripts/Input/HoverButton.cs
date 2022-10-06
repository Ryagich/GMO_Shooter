using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public bool IsPressed { get => dragSum > 0; }
    private float dragSum;
    private RectTransform activeRect;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        activeRect = GetComponent<RectTransform>();
        MobileInput.OnDrag += OnDrag;
        MobileInput.OnDragBegin += OnDrag;
        MobileInput.OnTap += OnDrag;
    }

    private void OnDrag(GestureEvent args)
    {
        if (!BoundsUtils.IsInsideTransform(activeRect, args.Position))
            return;
        dragSum += 0.4f;
        dragSum = Mathf.Min(dragSum, 1);
    }

    private void Update()
    {
        dragSum = Mathf.MoveTowards(dragSum, -1, 0.2f);
        image.color = IsPressed ? Color.gray : Color.white;
    }

    private void OnDestroy()
    {
        MobileInput.OnDrag -= OnDrag;
        MobileInput.OnDragBegin -= OnDrag;
        MobileInput.OnTap -= OnDrag;
    }
}
