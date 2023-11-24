using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTesting : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.LookAt(_target);
        Debug.DrawLine(transform.position, _target.position, Color.red);
    }
}
