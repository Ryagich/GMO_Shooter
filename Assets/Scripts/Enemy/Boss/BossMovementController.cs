using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    
    [SerializeField] private float _absoluteSpeed = 1.0f;
    [SerializeField] private float _range = 2.0f;
    [SerializeField] private Collider2D _area;

    private Bounds bounds;
    private Vector3 target;
    private Rigidbody2D rb;


    private const float DistanceTreshold = 0.3f;

    private void Awake()
    {
        bounds = _area.bounds;
        rb = GetComponent<Rigidbody2D>();
        target = GetNextTarget();
    }

    private void Update()
    {
      
    }

    private Vector3 GetNextTarget()
    {
        return RandomExtentions.InBounds(bounds);
    }

}
