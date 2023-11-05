using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
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

    public void Shoot()
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
        //////Bullet bullet = Instantiate(_prefabBullet, _container);
        //bullet.Init(_shootPosition);
    }

    public void LastShoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);
        Physics.Raycast(ray, out hit);
        //Debug.Log(hit.collider.name);

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
                //_cinemachineCamera.transform.parent = null;
                //_cinemachineCamera.Follow = bullet.transform;
                //_cinemachineCamera.LookAt = bullet.transform;
                _currentAmmo--;
                BulletsChanged?.Invoke(_currentAmmo);

                //StartCoroutine(Shooting());
                //if (hit.collider.GetComponent<Enemy>())
                //{
                //    _hitEnemy++;
                //    Debug.Log(_hitEnemy);

                //    if (_hitEnemy == 3)
                //    {
                //        for (int i = 0; i < 3; i++)
                //        {
                //            StartCoroutine(Shooting());
                //            Debug.Log("суперудар");
                //        }
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

    private IEnumerator Shooting()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Shoot();
        }
    }
}
