using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewShoot : MonoBehaviour
{
    [SerializeField] protected Bullet _prefabBullet;
    [SerializeField] protected Transform _container;
    [SerializeField] protected Transform _shootPosition;
    [SerializeField] private AudioPlugin _audioPlugin;
    //private Weapon _weapon;
    protected ObjectPool<Bullet> _pool;
    protected readonly int _maxAmmo = 5;
    protected bool _autoExpand = true;

    private void Start()
    {
        _pool = new ObjectPool<Bullet>(_prefabBullet, _maxAmmo, _container);
        _pool.GetAutoExpand(_autoExpand);
        //_weapon = GetComponent<Weapon>();
    }

    private void OnMouseDown()
    {
        if(_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            bullet.Init(_shootPosition);
            _audioPlugin.PlayOneShootKey();
            //_audioPlugin.PlayKey();
        }
        //_weapon.Shoot();
    }
}
