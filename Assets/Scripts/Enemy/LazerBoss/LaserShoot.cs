using System.Collections;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private LineRenderer _beam;
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private float _maxLength;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Enemy _enemy;

    private int _damage = 1;

    private void Awake()
    {
        _beam.enabled = false;
    }

    private void Activate()
    {
        _beam.enabled = true;
        _effect.Play();
    }

    private void Deactivate()
    {
        _beam.enabled = false;
        _beam.SetPosition(0, _muzzlePoint.position);
        _beam.SetPosition(1, _muzzlePoint.position);
        _effect.Stop();
    }

    private void Start()
    {
        Shooting();
    }

    private void FixedUpdate()
    {
        if (!_beam.enabled)
            return;

        if (!_enemy.IsDying)
        {
            Ray ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
            bool cast = Physics.Raycast(ray, out RaycastHit hit, _maxLength);
            Vector3 hitPosition = cast ? hit.point : _muzzlePoint.position + _muzzlePoint.forward * _maxLength;

            _beam.SetPosition(0, _muzzlePoint.position);
            _beam.SetPosition(1, hitPosition);
            _effect.transform.position = hitPosition;

            if (cast && hit.collider.TryGetComponent(out Destroy destroy))
                destroy.Destruction();

            if (cast && hit.collider.TryGetComponent(out Player player))
                player.ApplyDamage(_damage, _muzzlePoint.transform);
        }
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1.65f);
        yield return waitForSeconds;

        while (!_enemy.IsDying)
        {
            yield return waitForSeconds;
            Activate();
            yield return waitForSeconds;
            Deactivate();
        }
    }

    private void Shooting()
    {
        StartCoroutine(Shoot());
    }
}