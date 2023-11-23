using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _prefabBullet;
    [SerializeField] protected Transform _shootPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private Image _image;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    [SerializeField] private AudioSource _audioSource;

    protected ObjectPool<Bullet> _pool;

    private readonly int _maxAmmo = 4;

    protected bool _isFirstShoot = false;
    private int _currentAmmo;
    private bool _autoExpand = true;
    private int _hitEnemy = 0;
    private int _layerMask;

    public bool IsLastShoot { get; private set; } = false;
    public bool IsReload { get; private set; } = false;

    public event UnityAction FirstShoot;
    public event UnityAction<int,int> BulletsChanged;

    private void Start()
    {
        _pool = new ObjectPool<Bullet>(_prefabBullet, _maxAmmo, _container);
        _pool.GetAutoExpand(_autoExpand);
        _currentAmmo = _maxAmmo;
        _layerMask = 1 << 7;
        _layerMask = ~_layerMask;
    }

    public abstract void SuperShoot();

    public virtual void Shoot()
    {
        if (!IsReload)
        {
            if (!_isFirstShoot)
            {
                SetFirstShoot();
            }

            if (_currentAmmo > 0)
            {
                if (_hitEnemy == 2)
                {
                    _hitEnemy = 0;
                    BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);
                    SuperShoot();
                }
                else if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
                {
                    AmmoChanger(bullet);
                    _audioSource.Play();
                    IsLastShoot = _currentAmmo == 1;
                    EnemyHitChanger();
                }
            }
        }
    }

    public void LastShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            AmmoChanger(bullet);
            CinemachineMove(bullet);
            IsLastShoot = _currentAmmo == 1;
        }

        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private void EnemyHitChanger()
    {
        RaycastHit hit;
        Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            if (hit.collider.GetComponent<Enemy>())
            {
                _hitEnemy++; 
                BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);
            }
        }
        else
        {
            return;
        }
    }

    protected void MultiShoot(int count, float delay)
    {
        StartCoroutine(TripleShot(count, delay));
    }

    protected void BigShoot()
    {
        StartCoroutine(ScaleBullet());
    }

    private void CinemachineMove(Bullet bullet)
    {
        _cinemachineCamera.transform.parent = null;
        _cinemachineCamera.Follow = bullet.transform;
        _cinemachineCamera.LookAt = bullet.transform;
    }

    private void AmmoChanger(Bullet bullet)
    {
        bullet.Init(_shootPosition);
        _currentAmmo--;
        BulletsChanged?.Invoke(_currentAmmo,_hitEnemy);
    }

    private IEnumerator Reload()
    {
        SetReload(true);
        yield return new WaitForSeconds(3f);
        _currentAmmo = _maxAmmo;
        BulletsChanged?.Invoke(_currentAmmo,_hitEnemy);
        SetReload(false);
    }

    private void SetReload(bool flag)
    {
        _image.gameObject.SetActive(flag);
        IsReload = flag;
    }

    private IEnumerator TripleShot(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(delay);

            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                _audioSource.Play();
                bullet.Init(_shootPosition);
            }
        }
    }

    private IEnumerator ScaleBullet()
    {
        yield return new WaitForSeconds(0.15f);

        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            bullet.Init(_shootPosition);
            bullet.transform.localScale += new Vector3(3, 3, 3);
        }
    }

    protected void SetFirstShoot()
    {
        FirstShoot?.Invoke();
        _isFirstShoot = true;
    }
}