using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _radius = 0.001f;
    [SerializeField] private Effect _effect;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.6f);

    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SetActive());
        _effect.PlayEffect();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_bullet.Damage); 
            }

            if (hitCollider.TryGetComponent(out Destroy destroy))
            {
                destroy.GetDestroyObject();
            }

            if (hitCollider.TryGetComponent(out Barrel barrel))
            {
                barrel.Explosion();
            }
        }

        if (other.TryGetComponent(out Player player))
            player.ApplyDamage(_bullet.Damage);
    }

    private IEnumerator SetActive()
    {
        SetBullet(false);
        yield return _waitForSeconds;
        SetBullet(true);
        gameObject.SetActive(false);
    }

    private void SetBullet(bool flag)
    {
        GetComponent<Collider>().enabled = flag;
        _bullet.enabled = flag;
        _bullet.GetComponent<MeshRenderer>().enabled = flag;
    }
}
