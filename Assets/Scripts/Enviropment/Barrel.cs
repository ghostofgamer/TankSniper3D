using System.Collections;
using UnityEngine;

namespace Tank3D
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private ParticleSystem _ExplosionParticle;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
        private int _damage = 30;

        public void Explosion()
        {
            StartCoroutine(Explode());
        }

        private IEnumerator Explode()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);
            Instantiate(_ExplosionParticle, transform);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out Enemy enemy))
                    enemy.TakeDamage(_damage);

                if (hitCollider.TryGetComponent(out Destroy destroy))
                    destroy.Collapse();
            }

            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}