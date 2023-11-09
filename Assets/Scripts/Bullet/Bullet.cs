using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private readonly int _speed = 50;

    private float _radius = 0.001f;

    public int Damage => _damage;

    public void Init(Transform transform)
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
