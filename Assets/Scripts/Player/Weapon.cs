using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _container;

    private int _firstShoot = 0;
    public event UnityAction FirstShoot;
    
    public void Shoot()
    {
        if (_firstShoot == 0)
            FirstShoot?.Invoke();

        Bullet bullet = Instantiate(_prefabBullet, _container);
        bullet.Init(_shootPosition);
    }
}
