using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private readonly int _force = 1000;

    public void Fly()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(transform.up * _force);
    }
}
