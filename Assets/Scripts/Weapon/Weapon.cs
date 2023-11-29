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
    [SerializeField] private AudioClip _audioClip;

    protected ObjectPool<Bullet> _pool;

    private readonly int _maxAmmo = 5;

    protected bool _isFirstShoot = false;
    private int _currentAmmo;
    private bool _autoExpand = true;
    private int _hitEnemy = 0;
    private int _layerMask;

    public bool IsLastShoot { get; private set; } = false;
    public bool IsReload { get; private set; } = false;

    public event UnityAction FirstShoot;
    public event UnityAction<int, int> BulletsChanged;

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
                SetFirstShoot();

            if (_hitEnemy == 3)
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

    public void LastShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            AmmoChanger(bullet);
            CinemachineMove(bullet);
            IsLastShoot = _currentAmmo == 1;
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

    protected void BigShoot(Bullet bullet)
    {
        Bullet bigFireball = Instantiate(bullet, _container.transform);
        bigFireball.Init(_shootPosition);
        //StartCoroutine(ScaleBullet(bullet));
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
        BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);

        if (_currentAmmo <= 0)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        SetReload(true);
        yield return new WaitForSeconds(3f);
        _currentAmmo = _maxAmmo;
        BulletsChanged?.Invoke(_currentAmmo, _hitEnemy);
        SetReload(false);
    }

    private void SetReload(bool flag)
    {
        _image.gameObject.SetActive(flag);
        IsReload = flag;
    }

    private IEnumerator SomeShoot(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {

            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                _audioSource.PlayOneShot(_audioClip);
                //_audioSource.Play();
                bullet.Init(_shootPosition);
            }

            yield return new WaitForSeconds(delay);
            //yield return new WaitForSeconds(0.165f);
            //_audioSource.Stop();
        }
    }

    //private IEnumerator ScaleBullet(Bullet bullet)
    //{
    //    yield return new WaitForSeconds(0.15f);

    //    //if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
    //    //{
    //    //    bullet.Init(_shootPosition);
    //    //    bullet.transform.localScale += new Vector3(3, 3, 3);
    //    //}

    //    Bullet bigFireball = Instantiate(bullet, _container.transform);
    //    bigFireball.Init(_shootPosition);
    //}

    protected void SetFirstShoot()
    {
        FirstShoot?.Invoke();
        _isFirstShoot = true;
    }
}