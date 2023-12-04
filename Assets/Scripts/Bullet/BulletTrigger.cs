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

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.35f);

    private Coroutine _coroutine;
    private int _layerMask;

    private void OnEnable()
    {
        if (_bulletMover != null)
            _bulletMover.enabled = true;
    }

    private void Start()
    {
        _layerMask = 1 << 8;
        _layerMask = ~_layerMask;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);

        foreach (var hitCollider in hitColliders)
        {
            //if (_bulletMover != null)
            //    _bulletMover.enabled = false;


            if (hitCollider.TryGetComponent(out Block block))
            {
                Hit();
            }

            if (hitCollider.TryGetComponent(out Enemy enemy))
            {
                Hit();
                enemy.TakeDamage(_bullet.Damage);
            }

            if (hitCollider.TryGetComponent(out Destroy destroy))
            {
                Hit();
                destroy.Destruction();
            }

            if (hitCollider.TryGetComponent(out Barrel barrel))
            {
                Hit();
                barrel.Explosion();
            }

            if (hitCollider.TryGetComponent(out Enviropment enviropmentTest))
            {
                Hit();
            }

            //Hit();
        }

        if (other.TryGetComponent(out Player player))
        {
            Hit();

            if (!player.GetComponent<PlayerMover>()._isHidden)
            {
                player.ApplyDamage(_bullet.Damage);
            }
        }

        //hit?.Invoke();
    }

    public void Hit()
    {
        if (_bulletMover != null)
            _bulletMover.enabled = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _effect.PlayEffect();
        _coroutine = StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        SetBullet(false);
        yield return _waitForSeconds;
        SetBullet(true);
        gameObject.SetActive(false);
        //_bulletMover.enabled = true;
    }

    private void SetBullet(bool flag)
    {
        //GetComponent<Collider>().enabled = flag;
        //_bullet.enabled = flag;
        _meshRenderer.enabled = flag;
        //_bullet.GetComponent<MeshRenderer>().enabled = flag;
    }
}