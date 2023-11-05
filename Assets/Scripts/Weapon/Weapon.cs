using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private Image _image;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;

    private readonly int _maxAmmo = 4;

    private ObjectPool<Bullet> _pool;
    private bool _isFirstShoot = false;
    private int _currentAmmo;
    private bool _autoExpand = true;
    private int _hitEnemy = 0;

    public bool IsLastShoot { get; private set; } = true;
    public bool IsReload { get; private set; } = false;

    public event UnityAction FirstShoot;
    public event UnityAction<int> BulletsChanged;

    private void Start()
    {
        _pool = new ObjectPool<Bullet>(_prefabBullet, _maxAmmo, _container);
        _pool.GetAutoExpand(_autoExpand);
        _currentAmmo = _maxAmmo;
    }

    public abstract void SuperShoot();

    public virtual void Shoot()
    {
        if (!IsReload)
        {
            if (!_isFirstShoot)
            {
                FirstShoot?.Invoke();
                _isFirstShoot = true;
            }

            if (_currentAmmo > 0)
            {
                if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
                {
                    bullet.Init(_shootPosition);
                    _currentAmmo--;
                    BulletsChanged?.Invoke(_currentAmmo);
                }

                if (_currentAmmo <= 0)
                    StartCoroutine(Reload());
            }
        }
    }

    public void LastShoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);
        Physics.Raycast(ray, out hit);

        if (!_isFirstShoot)
        {
            FirstShoot?.Invoke();
            _isFirstShoot = true;
        }

        if (_currentAmmo > 0)
        {

            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                bullet.Init(_shootPosition);
                _cinemachineCamera.transform.parent = null;
                _cinemachineCamera.Follow = bullet.transform;
                _cinemachineCamera.LookAt = bullet.transform;
                _currentAmmo--;
                BulletsChanged?.Invoke(_currentAmmo);
                SuperShoot();

                //if (hit.collider.GetComponent<Enemy>())
                //{
                //    _hitEnemy++;

                //    if (_hitEnemy == 3)
                //    {
                //        for (int i = 0; i < 3; i++)
                //            StartCoroutine(Shooting());
                //    }
                //}
            }

            if (_currentAmmo <= 0)
                StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        SetReload(true);
        yield return new WaitForSeconds(3f);
        _currentAmmo = _maxAmmo;
        BulletsChanged?.Invoke(_currentAmmo);
        SetReload(false);
    }

    private void SetReload(bool flag)
    {
        _image.gameObject.SetActive(flag);
        IsReload = flag;
    }
}
