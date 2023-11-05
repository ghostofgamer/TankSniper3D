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

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit);
        Debug.DrawLine(ray.origin, hit.point, Color.red);

        //RaycastHit hit = Physics.Raycast(transform.position,transform.forward);

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
