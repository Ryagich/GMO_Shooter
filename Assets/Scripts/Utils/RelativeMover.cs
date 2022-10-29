using System.Collections.Generic;
using UnityEngine;

public class RelativeMover : MonoBehaviour
{
    private static HashSet<RelativeMover> instances;
    private Rigidbody2D rb;

    static RelativeMover()
    {
        instances = new HashSet<RelativeMover>();
    }

    public static void MoveCamera(Vector2 movement)
    {
        foreach (var instance in instances)
            instance.MoveInstance(-movement);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!instances.Contains(this))
            instances.Add(this);
    }

    public void MoveInstance(Vector2 movement)
    {
        if (rb != null)
            rb.position += movement;
        else
            transform.Translate(movement);
    }
}
