using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using UnityEditor;

[RequireComponent(typeof(BulletsController))]
[RequireComponent(typeof(SoundPlayer))]
public class Weapon__ : MonoBehaviour
{
    //public BulletsController BulletsController { get; private set; }

    //[Min(0.0f)] public float AttackCooldown = 0.5f;
    //[Min(0.0f)] public float Damage = 5.0f;

    //public float DPS { get => Damage / AttackCooldown; }

    
    //[Header("Bullet stats")]
    

    //protected bool isReady = true;
    //protected CinemachineImpulseSource impulseSource;

    //private LineRenderer line;
    //protected SoundPlayer player;

    //private void Awake()
    //{
    //    line = GetComponent<LineRenderer>();
    //    BulletsController = GetComponent<BulletsController>();
    //    player = GetComponent<SoundPlayer>();
    //}

    //public void SetImpulseSource(CinemachineImpulseSource impulseSource)
    //{
    //    this.impulseSource = impulseSource;
    //}

    //public virtual void Shoot()
    //{
        
    //}

   

    //private void FixedUpdate()
    //{
    //    DrawLine();
    //    //Debug.DrawRay(_shootPoint.position, direction * offset, Color.white);

    //    var direction = transform.right;
    //    var offset = _speed * _time * Time.fixedDeltaTime;
    //    var hit = Physics2D.Raycast(_shootPoint.position, direction, offset, mask);

    //    if (isReady && hit.collider != null
    //        && BulletsController.HasBullets)
    //        Shoot();

    //}

    
}
