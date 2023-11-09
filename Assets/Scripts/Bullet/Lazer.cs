using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Bullet
{
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _maxLength;
    [SerializeField] private BulletTrigger _bulletTrigger;

    private void FixedUpdate()
    {
        HitEffect();
    }

    private void HitEffect()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, _maxLength);
        Vector3 hitPosition = cast ? hit.point : transform.position + transform.forward * _maxLength;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, hitPosition);
        _hitParticles.transform.position = hitPosition;
    }
}
