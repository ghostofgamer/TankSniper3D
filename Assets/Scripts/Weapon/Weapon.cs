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
    [SerializeField] private Image _image;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;
    //[SerializeField] private AudioSource _audioSource;
    //[SerializeField] private SourceAudio _sourceAudio;
    [SerializeField] private AudioPlugin _audioPlugin;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField]private Transform _defPos;
    protected ObjectPool<Bullet> _pool;

    protected readonly int _maxAmmo = 5;

    protected bool _isFirstShoot = false;
    private int _currentAmmo;
    protected bool _autoExpand = true;
    private int _hitEnemy = 0;
    private int _layerMask;

    public bool IsReload { get; private set; } = false;

    public event UnityAction FirstShoot;
    public event UnityAction<int, int> BulletsChanged;

    RaycastHit hit;
    Ray ray;

    protected virtual void Start()
    {
        Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);
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
            else if (_killedInfo.IsLastEnemy)
            {
                LastShoot();
                EnemyHitChanger();
            }
            else if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                AmmoChanger(bullet);
                //_audioSource.Play();
                //_sourceAudio.Play("Shoot1Lvl");
                _audioPlugin.PlayKey();
                EnemyHitChanger();
            }
        }
    }

    public void LastShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            AmmoChanger(bullet);
            //_audioSource.Play();
            //_sourceAudio.Play("Shoot1Lvl");
            _audioPlugin.PlayKey();
            RaycastHit hit;
            Ray ray = new Ray(_shootPosition.position, _shootPosition.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    //if (enemy.IsBoss && enemy.CurrentHealth < 30)
                    //{
                    //    _cameraAim.CinemachineMove(bullet);
                    //    _cameraAim.OnCinemaMachine();
                    //}
                    if (!enemy.IsBoss|| enemy.IsBoss && enemy.CurrentHealth <= bullet.Damage)
                    {
                        _cameraAim.CinemachineMove(bullet);
                        _cameraAim.OnCinemaMachine();
                    }
                }
            }
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
            //Transform transformmm = _shootPosition;
            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                //_audioSource.PlayOneShot(_audioClip);
                //_sourceAudio.PlayOneShot("Shoot1Lvl");
                _audioPlugin.PlayOneShootKey();
                //_audioSource.Play();
                bullet.Init(_shootPosition);
                //Vector3 vector = _shootPosition.position + Random.insideUnitSphere * 1.65f;
                //transformmm.position = vector;
            }

            yield return new WaitForSeconds(delay);
            Vector3 vector = _shootPosition.position + Random.insideUnitSphere * 1.5f;
            _shootPosition.position = vector;
            //yield return new WaitForSeconds(0.165f);
            //_audioSource.Stop();
        }

        _shootPosition = _defPos;
    }

    protected void SetFirstShoot()
    {
        FirstShoot?.Invoke();
        _isFirstShoot = true;
    }
}