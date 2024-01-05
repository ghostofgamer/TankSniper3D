using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    protected readonly int _maxAmmo = 5;

    [SerializeField] protected Bullet PrefabBullet;
    [SerializeField] protected Transform ShootPosition;
    [SerializeField] protected Transform Container;
    [SerializeField] protected AudioSource AudioSource;

    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private CameraAim _cameraAim;
    //[SerializeField] private Transform _defaultPosition;
    [SerializeField] private ReloadSlider _reload;
    [SerializeField] private Image _imageAim;

    protected ObjectPool<Bullet> _pool;
    protected bool IsFirstShoot = false;
    protected bool AutoExpand = true;

    private int _currentAmmo;
    private int _hitEnemy = 0;
    private int _maxHitEnemy = 3;
    private int _layerMask;
    private int _maskIndex = 7;
    //private float _factor = 1.5f;
    private bool _isLastShoot = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private WaitForSeconds _waitForReload = new WaitForSeconds(3f);

    public event UnityAction FirstShoot;
    public event UnityAction<int, int> BulletsChanged;

    public bool IsReload { get; private set; } = false;

    protected virtual void Start()
    {
        Ray ray = new Ray(ShootPosition.position, ShootPosition.forward);
        _pool = new ObjectPool<Bullet>(PrefabBullet, _maxAmmo, Container);
        _pool.GetAutoExpand(AutoExpand);
        _currentAmmo = _maxAmmo;
        _layerMask = 1 << _maskIndex;
        _layerMask = ~_layerMask;
    }

    public abstract void SuperShoot();

    public virtual void Shoot()
    {
        if (!IsReload)
        {
            if (!IsFirstShoot)
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
            else if (_pool.TryGetObject(out Bullet bullet, PrefabBullet))
            {
                GetBullet(bullet);
                AmmoChanger(bullet);
                AudioSource.Play();
                EnemyHitChanger();
            }
        }
    }

    public void LastShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, PrefabBullet))
        {
            GetBullet(bullet);
            EnemyHitChanger();
            AudioSource.Play();
            RaycastHit hit;
            Ray ray = new Ray(ShootPosition.position, ShootPosition.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    if (!enemy.IsBoss && !enemy.IsDying || enemy.IsBoss && enemy.CurrentHealth <= bullet.Damage)
                    {
                        _isLastShoot = true;
                        _cameraAim.CinemachineMove(bullet);
                        _cameraAim.OnCinemaMachine();
                        _imageAim.enabled = false;
                    }
                }
            }

            AmmoChanger(bullet);
        }
    }

    protected void MultiShoot(int count, float delay)
    {
        //StartCoroutine(SomeShoot(count, delay));
    }

    protected void SetFirstShoot()
    {
        FirstShoot?.Invoke();
        IsFirstShoot = true;
    }

    private void EnemyHitChanger()
    {
        RaycastHit hit;
        Ray ray = new Ray(ShootPosition.position, ShootPosition.forward);

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

    private void GetBullet(Bullet bullet)
    {
        bullet.Init(ShootPosition);
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

    //private IEnumerator SomeShoot(int count, float delay)
    //{
    //    WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

    //    for (int i = 0; i < count; i++)
    //    {
    //        if (_pool.TryGetObject(out Bullet bullet, PrefabBullet))
    //        {
    //            _audioSource.Play();
    //            bullet.Init(ShootPosition);
    //        }

    //        yield return waitForSeconds;
    //        Vector3 vector = ShootPosition.position + Random.insideUnitSphere * _factor;
    //        ShootPosition.position = vector;
    //    }

    //    ShootPosition.position = _defaultPosition.position;
    //}
}