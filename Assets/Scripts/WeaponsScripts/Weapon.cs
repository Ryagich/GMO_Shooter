using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Min(0.0f)] public float AttackCooldown = 0.5f;
    [Min(0.0f)] public float Damage = 5.0f;
    public BulletsController BulletsController;

    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] private LayerMask mask = new LayerMask();

    protected bool isReady = true;
    protected Cinemachine.CinemachineCollisionImpulseSource inpulse;

    private LineRenderer line;

    [Header("Bullet stats")]
    [SerializeField, Min(0.0f)] protected float _speed = 1.0f;
    [SerializeField, Min(0.0f)] protected float _time = 1.0f;

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
        bullet.SetStats(_speed, Damage, _time);

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

        Debug.DrawRay(_shootPoint.position, direction * offset, Color.white);

        if (hit.collider == null)
            return;

        if ((hit.collider.gameObject.GetComponent<DropBox>() != null
          || hit.collider.gameObject.GetComponent<Enemy>() != null
          || hit.collider.gameObject.GetComponent<BossHpController>() != null
          && hit.collider.gameObject.GetComponent<BossHpController>().CanAttacked)
          && isReady && BulletsController.HasBullets)
            Shoot();
    }

    private void DrawLine()
    {
        var vectorArray = new Vector3[2];
        vectorArray[0] = _shootPoint.position;
        vectorArray[1] = _shootPoint.position + transform.right * _speed * _time * Time.fixedDeltaTime;
        line.SetPositions(vectorArray);
    }

//    private void Update()
//    {
//        if (Input.GetKey(KeyCode.Mouse0) && isReady
//            && BulletsController.HasBullets)
//        {
//            Shoot();
//        }
//    }
}
