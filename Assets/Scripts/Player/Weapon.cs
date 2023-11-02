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

    private readonly int _maxAmmo = 4;

    private List<Bullet> _bullets = new List<Bullet>();
    private bool _isFirstShoot = false;
    private int _currentAmmo;

    public bool IsReload { get; private set; } = false;

    public event UnityAction FirstShoot;
    public event UnityAction<int> BulletsChanged;

    private void Start()
    {
        SetBullets();
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
                var bullet = _bullets.FirstOrDefault(p => p.gameObject.activeSelf == false);
                bullet.gameObject.SetActive(true);
                bullet.Init(_shootPosition);
                _currentAmmo--;
                BulletsChanged?.Invoke(_currentAmmo);

                if (_currentAmmo <= 0)
                    StartCoroutine(Reload());
            }
        }
        //////Bullet bullet = Instantiate(_prefabBullet, _container);
        //bullet.Init(_shootPosition);
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

    private void SetBullets()
    {
        for (int i = 0; i < _maxAmmo; i++)
        {
            Bullet bullet = Instantiate(_prefabBullet, _container);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }
    }
}
