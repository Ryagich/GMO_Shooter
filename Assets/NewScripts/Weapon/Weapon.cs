using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float DPS => _damage / _shootDelay;
    public float Damage => _damage;
    public float Speed => 1 / _shootDelay;

    public BulletsController BulletsController => _bulletsController;


    [SerializeField] private LayerMask _raycastMask;
    [SerializeField] private float _shakeAmplitude = 0.5f;   

    [Header("Children")]
    [SerializeField] private Muzzleflash _muzzleflash;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private BulletsController _bulletsController;
    [SerializeField] private Transform _shooter;

    [Header("Stats")]
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay, _bulletSpeed, _range;

    private bool isReady = true;

    private LineRenderer lineRenderer;
    private CinemachineImpulseSource impulseSource;
    private IShooter shooter;

    private void Start()
    {
        shooter = _shooter.GetComponent<IShooter>();
    }

    private void Update()
    {
        if (lineRenderer)
            UpdateLine();
        if (IsRaycastTriggered() && isReady && _bulletsController.HasBullets)
            Shoot();
    }

    public void Init(LineRenderer lineRenderer, CinemachineImpulseSource impulseSource)
    {
        this.lineRenderer = lineRenderer;
        this.impulseSource = impulseSource;
    }

    private void Shoot()
    {
        shooter.Shoot(_bulletSpeed, _damage, _range);
        _soundPlayer.Play();
        if (impulseSource)
            impulseSource.GenerateImpulse(_shakeAmplitude);
        isReady = false;
        _bulletsController.SubtractBullets(1);
        _muzzleflash.Flash();
        CoroutineHolder.Instance.StartCoroutine(CoolDown());
    }

    protected IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_shootDelay);
        isReady = true;
    }

    private bool IsRaycastTriggered()
    {
        var direction = transform.right;
        var hit = Physics2D.Raycast(_shooter.position, direction.normalized, _range, _raycastMask);
        var doesHit = hit.collider != null;
        Debug.DrawRay(_shooter.position, direction.normalized * _range, doesHit ? Color.red : Color.white);
        return doesHit;
    }

    private void UpdateLine()
    {
        var vectorArray = new Vector3[2];
        vectorArray[0] = _shooter.position - Vector3.back * 0.01f;
        vectorArray[1] = vectorArray[0] + _range * transform.right - Vector3.back * 0.01f;
        lineRenderer.SetPositions(vectorArray);
    }
}
