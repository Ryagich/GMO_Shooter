using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(RelativeMover))]
public class ScreenWarp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private RelativeMover relativeMover;
    private new Camera camera;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        relativeMover = GetComponent<RelativeMover>();
        camera = Camera.main;
    }

    void Update()
    {
        var camBounds = BoundsUtils.GetCameraViewRect2d(camera);
        var spriteBounds = BoundsUtils.BoundsToRect(spriteRenderer.bounds);
        if (spriteBounds.yMax < camBounds.yMin)
            relativeMover.MoveInstance(Vector2.up * (camBounds.size.y + spriteBounds.size.y));
        if (spriteBounds.xMax < camBounds.xMin)
            relativeMover.MoveInstance(Vector2.right * (camBounds.size.x + spriteBounds.size.x));

        if (spriteBounds.yMin > camBounds.yMax)
            relativeMover.MoveInstance(Vector2.down * (camBounds.size.y + spriteBounds.size.y));
        if (spriteBounds.xMin > camBounds.xMax)
            relativeMover.MoveInstance(Vector2.left * (camBounds.size.x + spriteBounds.size.x));
    }
}
