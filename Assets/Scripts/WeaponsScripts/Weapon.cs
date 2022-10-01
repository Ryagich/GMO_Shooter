using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

[RequireComponent(typeof(BulletsController))]
public class Weapon : MonoBehaviour
{
    public BulletsController BulletsController { get; private set; }

    [Min(0.0f)] public float AttackCooldown = 0.5f;
    [Min(0.0f)] public float Damage = 5.0f;

    public float DPS { get => Damage / AttackCooldown; }

    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected LayerMask mask;
    [Header("Bullet stats")]
    [SerializeField, Min(0.0f)] protected float _speed = 1.0f;
    [SerializeField, Min(0.0f)] protected float _time = 1.0f;
    [SerializeField, Min(0.0f)] protected float _shakeAmplitude = 0.5f;

    protected bool isReady = true;
    protected CinemachineImpulseSource impulseSource;

    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        BulletsController = GetComponent<BulletsController>();
    }

    public void SetImpulseSource(CinemachineImpulseSource impulseSource)
    {
        this.impulseSource = impulseSource;
    }

    public virtual void Shoot()
    {
        var bullet = Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
        bullet.SetStats(_speed, Damage, _time);

        impulseSource.GenerateImpulse(_shakeAmplitude);
        isReady = false;
        BulletsController.SubtractBullets(1);
        Camera.main.GetComponent<MonoBehaviour>().StartCoroutine(CoolDown());
    }

    protected IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        isReady = true;
    }

    private void FixedUpdate()
    {
        DrawLine();
        //Debug.DrawRay(_shootPoint.position, direction * offset, Color.white);

        var direction = transform.right;
        var offset = _speed * _time * Time.fixedDeltaTime;
        var hit = Physics2D.Raycast(_shootPoint.position, direction, offset, mask);

        if (isReady && hit.collider != null
            && BulletsController.HasBullets)
            Shoot();

    }

    private void DrawLine()
    {
        var vectorArray = new Vector3[2];
        vectorArray[0] = _shootPoint.position;
        vectorArray[1] = _shootPoint.position
            + transform.right * _speed * _time * Time.fixedDeltaTime;
        line.SetPositions(vectorArray);
    }
}
