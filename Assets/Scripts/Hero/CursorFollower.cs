using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    [SerializeField] private float offset = 0.0f;

    private void Update()
    {
        var diference = Camera.main.ScreenToWorldPoint(Input.mousePosition)
                      - transform.position;
        var rotatetZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotatetZ + offset);

        var localScale = Vector3.one;

        localScale.y = rotatetZ > 90 || rotatetZ < -90 ? -1.0f : 1.0f;
        transform.localScale = localScale;
    }
}
