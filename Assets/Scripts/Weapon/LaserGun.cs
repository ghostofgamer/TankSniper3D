using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _maxLength;
    [SerializeField] private ParticleSystem _hitParticles;

    private void Awake()
    {
        _lineRenderer.enabled = false;
        _lineRenderer.SetPosition(0, _shootPosition.position);
        _lineRenderer.SetPosition(1, _shootPosition.position);
    }

    public void Activate()
    {
        _lineRenderer.enabled = true;
        _hitParticles.Play();
    }

    public void Deactivate()
    {
        _lineRenderer.enabled = false;
        _hitParticles.Stop();
        _lineRenderer.SetPosition(0, _shootPosition.position);
        _lineRenderer.SetPosition(1, _shootPosition.position);
    }

    public override void Shoot()
    {
        Activate();
    }


    public override void SuperShoot()
    {
        
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, _maxLength);
        Vector3 hitPosition = cast ? hit.point : _shootPosition.position + _shootPosition.forward * _maxLength;
        _lineRenderer.SetPosition(0, _shootPosition.position);
        _lineRenderer.SetPosition(1, hitPosition);
        _hitParticles.transform.position = hitPosition;

        if (cast && hit.collider.TryGetComponent(out Destroy destroy))
            destroy.GetDestroyObject();
    }
}
