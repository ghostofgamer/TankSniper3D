using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _container;

    private readonly int _speed = 10;
    private readonly int _camRotationY = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet bullet = Instantiate(_prefabBullet, _container);
            bullet.Init(_position);
        }

        float horizontal = Input.GetAxis("Mouse Y");
        float vertical = Input.GetAxis("Mouse X");

        if (horizontal != 0)
        {
            var tmp = _camRotationY - horizontal * Time.deltaTime;
            transform.Rotate(transform.right, -horizontal);
        }

        if (vertical != 0)
        {
            var tmp = _camRotationY - vertical * Time.deltaTime;
            transform.Rotate(transform.up, vertical);
        }
    }
}
