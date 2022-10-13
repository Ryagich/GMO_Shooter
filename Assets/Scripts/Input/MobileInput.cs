using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static event Action<GestureEvent> OnTap;
    public static event Action<GestureEvent> OnDragBegin;
    public static event Action<GestureEvent> OnDrag;
    public static event Action<GestureEvent> OnDragEnd;

    public const float MinClickTime = 0.001f;
    public const float MaxClickTime = 0.01f;
    public const float MaxClickDistance = 10f;

    public bool Enabled = true;
    public bool LogEvents = false;
    private Dictionary<int, Gesture> gestures;

    private void Awake()
    {
        gestures = new Dictionary<int, Gesture>();
    }

    private void Update()
    {
        if (!Enabled)
            return;
        var toRemove = new List<Gesture>();
        foreach (var touch in Input.touches)
        {
            if (!gestures.ContainsKey(touch.fingerId))
                gestures.Add(touch.fingerId, new Gesture(touch));
            var result = gestures[touch.fingerId].Update(touch);
            if (result != null)
                SendGesture(result);
            gestures[touch.fingerId].Updated = true;
        }
        foreach (var gesture in gestures.Values)
        {
            if (!gesture.Updated)
            {
                var result = gesture.LastUpdate();
                toRemove.Add(gesture);
                SendGesture(result);
            }
            gesture.Updated = false;
        }

        foreach (var rem in toRemove)
            gestures.Remove(rem.Touch.fingerId);
        toRemove.Clear();
    }

    private void SendGesture(GestureEvent eventArgs)
    {
        if (LogEvents)
            GestureLogger.Log(eventArgs);

        if (eventArgs == null)
            return;
        switch (eventArgs.Type)
        {
            case GestureType.None:
                break;
            case GestureType.Tap:
                OnTap?.Invoke(eventArgs);
                break;
            case GestureType.Drag:
                OnDrag?.Invoke(eventArgs);
                break;
            case GestureType.DragBegin:
                OnDragBegin?.Invoke(eventArgs);
                break;
            case GestureType.DragEnd:
                OnDragEnd?.Invoke(eventArgs);
                break;
            default:
                break;
        }
    }
}

public enum GestureType
{
    None, Tap, Drag, DragBegin, DragEnd
}

public class GestureEvent
{
    public readonly GestureType Type;
    public readonly Vector2 Position;
    public readonly int Finger;

    public GestureEvent(GestureType type, Vector2 position, int finger)
    {
        Type = type;
        Position = position;
        this.Finger = finger;
    }
}

public class Gesture
{
    public bool Updated;
    public Touch Start, Touch;
    private bool isDrag;
    private float startTime;

    public Gesture(Touch touch)
    {
        startTime = Time.time;
        Start = touch;
        Touch = touch;
        Updated = true;
        isDrag = false;
    }

    public GestureEvent Update(Touch touch)
    {
        this.Touch = touch;
        Updated = true;

        var pos = touch.position;
        var dTime = Time.time - startTime;
        var dis = Vector2.Distance(pos, Start.position);

        if (dTime < MobileInput.MaxClickTime && dis < MobileInput.MaxClickDistance)
            return null;
        if (isDrag == false)
        {
            isDrag = true;
            return new GestureEvent(GestureType.DragBegin, pos, touch.fingerId);
        }
        return new GestureEvent(GestureType.Drag, pos, touch.fingerId);
    }

    public GestureEvent LastUpdate()
    {
        var pos = Touch.position;
        var dTime = Time.time - startTime;
        if (isDrag)
            return new GestureEvent(GestureType.DragEnd, pos, Touch.fingerId);
        if (dTime < MobileInput.MinClickTime)
            return null;
        if (dTime < MobileInput.MaxClickTime)
            return new GestureEvent(GestureType.Tap, pos, Touch.fingerId);
        return new GestureEvent(GestureType.DragEnd, pos, Touch.fingerId);
    }
}

public static class GestureLogger
{
    private static GestureType lastEvent = GestureType.None;

    public static void Log(GestureEvent gesture)
    {
        if (gesture == null)
            return;
        if (lastEvent != gesture.Type || lastEvent != GestureType.Drag)
            Debug.Log(Enum.GetName(typeof(GestureType), gesture.Type));
        lastEvent = gesture.Type;
    }
}