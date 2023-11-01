using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _startTransform;

    private readonly float _limitAngles = 50f;
    private readonly float _speed = 1f;

    private float vertical;
    private float horizontal;

    public void Shoot()
    {
        Bullet bullet = Instantiate(_prefabBullet, _container);
        bullet.Init(_shootPosition);
    }

    public void Rotate()
    {
        vertical += Input.GetAxis("Mouse Y");
        horizontal += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(Mathf.Clamp(-vertical, -_limitAngles, _limitAngles), Mathf.Clamp(horizontal, -_limitAngles, _limitAngles), 0);
    }

    public void ResetRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _startTransform.rotation, _speed * Time.deltaTime);
    }
}
