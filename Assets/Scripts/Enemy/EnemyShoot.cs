using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private float _delay;

    private readonly int _ammoCount = 10;

    private ObjectPool<Bullet> _pool;
    private bool _autoExpand = true;

    private void Start()
    {
        _pool = new ObjectPool<Bullet>(_prefab, _ammoCount, _container);
        _pool.GetAutoExpand(_autoExpand);
    }

    public IEnumerator Shoot()
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            yield return _waitForSeconds;
            Shooting();
            //Bullet bullet = Instantiate(_prefab, _container);
            //bullet.Init(_shootPosition);
            //yield return _waitForSeconds;
        }
    }

    private void Shooting()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefab))
        {
            bullet.Init(_shootPosition);
        }
    }
}
