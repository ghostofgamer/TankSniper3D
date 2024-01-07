using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private readonly int Force = 1000;

    [SerializeField] private Rigidbody _rigidbody;

    public void Fly()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(transform.up * Force);
    }
}