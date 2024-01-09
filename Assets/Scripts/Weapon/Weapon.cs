using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    protected readonly int MaxAmmo = 5;

    [SerializeField] protected Bullet PrefabBullet;
    [SerializeField] protected Transform ShootPosition;
    [SerializeField] protected Transform Container;
    [SerializeField] protected AudioSource AudioSource;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private CameraAim _cameraAim;
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
    private bool _isLastShoot = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private WaitForSeconds _waitForReload = new WaitForSeconds(3f);

    public event UnityAction FirstShoot;

    public event UnityAction<int, int> BulletsChanged;

    public bool IsReload { get; private set; } = false;

    protected virtual void Start()
    {
        Ray ray = new Ray(ShootPosition.position, ShootPosition.forward);
        _pool = new ObjectPool<Bullet>(PrefabBullet, MaxAmmo, Container);
        _pool.SetAutoExpand(AutoExpand);
        _currentAmmo = MaxAmmo;
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
                BulletInitialization(bullet);
                AmmoChanger(bullet);
                AudioSource.Play();
                ChangeEnemyHit();
            }
        }
    }

    public void LastShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, PrefabBullet))
        {
            BulletInitialization(bullet);
            ChangeEnemyHit();
            AudioSource.Play();
            RaycastHit hit;
            Ray ray = new Ray(ShootPosition.position, ShootPosition.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    if (!enemy.IsBoss && !enemy.IsDying || enemy.IsBoss && enemy.CurrentHealth <= bullet.Damage)
                        LastFlyBullet(bullet);
                }
            }

            AmmoChanger(bullet);
        }
    }

    protected void SetFirstShoot()
    {
        FirstShoot?.Invoke();
        IsFirstShoot = true;
    }

    private void LastFlyBullet(Bullet bullet)
    {
        _isLastShoot = true;
        _cameraAim.CinemachineMove(bullet);
        _cameraAim.PlayCinemachine();
        _imageAim.enabled = false;
    }

    private void ChangeEnemyHit()
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

    private void BulletInitialization(Bullet bullet)
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
        _currentAmmo = MaxAmmo;
        BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);
        SetReload(false);
    }

    private void SetReload(bool flag)
    {
        _reload.gameObject.SetActive(flag);
        IsReload = flag;
    }
}