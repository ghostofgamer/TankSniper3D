using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _container;

    private readonly int _speed = 10;
    private readonly int _speedRotate = 3;
    private float _camRotationY = 0;
    private float _limitAnglesY = 15;
    private float _limitAnglesX = 15;
    private float vertical;
    private float horizontal;

    private void Update()
    {
        vertical += Input.GetAxis("Mouse Y");
        horizontal += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(Mathf.Clamp(-vertical, -50f, 50f), Mathf.Clamp(horizontal, -50f, 50f), 0);
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(_prefabBullet, _container);
        bullet.Init(_position);
    }
}
