using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private readonly int _speed = 50;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
