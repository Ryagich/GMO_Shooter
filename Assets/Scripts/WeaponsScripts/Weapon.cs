using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Min(0.0f)] public float AttackCooldown = 0.5f, Damage = 5.0f;
    public BulletsController BulletsController;

    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected LayerMask mask = new LayerMask();

    protected bool isReady = true;
    protected Cinemachine.CinemachineCollisionImpulseSource inpulse;

    private LineRenderer line;

    [Header("Bullet stats")]
    [SerializeField, Min(0.0f)] protected float _speed = 1.0f, _time = 1.0f;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    public void SetInpulse(Cinemachine.CinemachineCollisionImpulseSource inpulse)
    {
        this.inpulse = inpulse;
    }

    public virtual void Shoot()
    {
        var bullet = Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
        bullet.SetStats(_speed, Damage, _time, mask);

        inpulse.GenerateImpulse();
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

        var direction = transform.right;
        var offset = _speed * _time * Time.fixedDeltaTime;
        var hit = Physics2D.Raycast(_shootPoint.position, direction, offset, mask);

        //Debug.DrawRay(_shootPoint.position, direction * offset, Color.white);

        if (hit.collider == null)
            return;

        if (isReady && BulletsController.HasBullets)
            Shoot();
    }

    private void DrawLine()
    {
        var vectorArray = new Vector3[2];
        vectorArray[0] = _shootPoint.position;
        vectorArray[1] = _shootPoint.position + transform.right * _speed * _time * Time.fixedDeltaTime;
        line.SetPositions(vectorArray);
    }
}
