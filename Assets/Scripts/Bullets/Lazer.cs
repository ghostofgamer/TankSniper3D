using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Lazer : Bullet
    {
        [SerializeField] private ParticleSystem _hitParticles;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _maxLength;

        private Ray _ray = new Ray();

        private void Awake()
        {
            _ray = new Ray(transform.position, transform.forward);
        }

        private void FixedUpdate()
        {
            HitEffect();
        }

        private void HitEffect()
        {
            bool cast = Physics.Raycast(_ray, out RaycastHit hit, _maxLength);
            Vector3 hitPosition = cast ? hit.point : transform.position + transform.forward * _maxLength;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, hitPosition);
            _hitParticles.transform.position = hitPosition;
        }
    }
}