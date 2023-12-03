using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField]private int _speed = 50;
    //[SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        //_rigidbody.AddForce(transform.forward * _speed /** Time.deltaTime*/);
        ////_rigidbody.AddForce(Vector3.forward * _speed/* * Time.deltaTime*/);
    }
}
