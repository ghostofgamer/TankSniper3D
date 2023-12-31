using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletTrigger : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _radius = 0.001f;
    [SerializeField] private Effect _effect;
    [SerializeField] private BulletMover _bulletMover;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private HomingRocket _homingRocket;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.35f);
    private Coroutine _coroutine;
    private int _layerMask;
    private int _layer = 8;

    private void OnEnable()
    {
        if (_bulletMover != null)
            _bulletMover.enabled = true;

        if (_homingRocket != null && _homingRocket.enabled == false)
            _homingRocket.enabled = true;
    }

    private void Start()
    {
        _layerMask = 1 << _layer;
        _layerMask = ~_layerMask;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);

        if (other.TryGetComponent(out Bullet bullet))
            return;

        Hit();

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(_bullet.Damage);

            if (hitCollider.TryGetComponent(out Destroy destroy))
                destroy.Destruction();

            if (hitCollider.TryGetComponent(out Barrel barrel))
                barrel.Explosion();

            if (hitCollider.TryGetComponent(out Player player))
            {
                if (!player.GetComponent<PlayerMover>()._isHidden && !player.IsDead)
                    player.ApplyDamage(_bullet.Damage, _bullet._shootPosition);
            }
        }
    }

    public void Hit()
    {
        if (_bulletMover != null)
            _bulletMover.enabled = false;

        if (_homingRocket != null)
            _homingRocket.enabled = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _effect.PlayEffect();
        _coroutine = StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        yield return _waitForSeconds;
        transform.position = _bullet._shootPosition.position;
        gameObject.SetActive(false);
    }
}