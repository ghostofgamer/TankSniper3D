using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _container;

    private readonly float _limitAngles = 50f;

    private float vertical;
    private float horizontal;

    private void Update()
    {
        vertical += Input.GetAxis("Mouse Y");
        horizontal += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(Mathf.Clamp(-vertical, -_limitAngles, _limitAngles), Mathf.Clamp(horizontal, -_limitAngles, _limitAngles), 0);
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(_prefabBullet, _container);
        bullet.Init(_position);
    }
}
