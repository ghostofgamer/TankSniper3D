using Cinemachine;
using Plugins.Audio.Core;
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
    [SerializeField] protected Transform _container;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    [SerializeField] private AudioPlugin _audioPlugin;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private Transform _defPos;
    [SerializeField] private ReloadSlider _reload;

    protected readonly int _maxAmmo = 5;

    protected ObjectPool<Bullet> _pool;
    protected bool _isFirstShoot = false;
    private int _currentAmmo;
    protected bool _autoExpand = true;
    private int _hitEnemy = 0;
    private int _maxHitEnemy = 3;
    private int _layerMask;
    private int _maskIndex = 7;
    private float _factor = 1.5f;
    private bool _isLastShoot = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private WaitForSeconds _waitForReload = new WaitForSeconds(3f);

    public bool IsReload { get; private set; } = false;

    public event UnityAction FirstShoot;
    public event UnityAction<int, int> BulletsChanged;

    protected virtual void Start()
    {
        Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);
        _pool = new ObjectPool<Bullet>(_prefabBullet, _maxAmmo, _container);

        _pool.GetAutoExpand(_autoExpand);
        _currentAmmo = _maxAmmo;
        _layerMask = 1 << _maskIndex;
        _layerMask = ~_layerMask;
    }

    public abstract void SuperShoot();

    public virtual void Shoot()
    {
        if (!IsReload)
        {
            if (!_isFirstShoot)
                SetFirstShoot();

            if (_hitEnemy == _maxHitEnemy)
            {
                _hitEnemy = 0;
                BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);
                SuperShoot();
            }
            else if (_killedInfo.IsLastEnemy)
            {
                LastShoot();
            }
            else if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                GetBullet(bullet);
                AmmoChanger(bullet);
                _audioPlugin.PlayKey();
                EnemyHitChanger();
            }
        }
    }

    public void LastShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            GetBullet(bullet);
            EnemyHitChanger();
            _audioPlugin.PlayKey();
            RaycastHit hit;
            Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    if (!enemy.IsBoss || enemy.IsBoss && enemy.CurrentHealth <= bullet.Damage)
                    {
                        _isLastShoot = true;
                        _cameraAim.CinemachineMove(bullet);
                        _cameraAim.OnCinemaMachine();
                    }
                }
            }

            AmmoChanger(bullet);
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
        StartCoroutine(SomeShoot(count, delay));
    }

    private void GetBullet(Bullet bullet)
    {
        bullet.Init(_shootPosition);
    }

    private void AmmoChanger(Bullet bullet)
    {
        _currentAmmo--;
        BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);

        if (_currentAmmo <= 0 && !_isLastShoot)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return _waitForSeconds;
        SetReload(true);
        yield return _waitForReload;
        _currentAmmo = _maxAmmo;
        BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);
        SetReload(false);
    }

    private void SetReload(bool flag)
    {
        _reload.gameObject.SetActive(flag);
        IsReload = flag;
    }

    private IEnumerator SomeShoot(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                _audioPlugin.PlayOneShootKey();
                bullet.Init(_shootPosition);
            }

            yield return new WaitForSeconds(delay);
            Vector3 vector = _shootPosition.position + Random.insideUnitSphere * _factor;
            _shootPosition.position = vector;
        }

        _shootPosition = _defPos;
    }

    protected void SetFirstShoot()
    {
        FirstShoot?.Invoke();
        _isFirstShoot = true;
    }
}