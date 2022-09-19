using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    private Vector3 position = new Vector3();

    private void Update()
    {
        position = Camera.main.WorldToScreenPoint(transform.position);

        transform.localRotation = Input.mousePosition.x < position.x ?
                               Quaternion.Euler(0, 180, 0)
                             : Quaternion.Euler(0, 0, 0);
    }
}
