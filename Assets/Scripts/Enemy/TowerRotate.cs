using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _speedRotation = 3f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 relativePosition = transform.position - _target.position;
        Quaternion rotation = Quaternion.LookRotation(-relativePosition);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
    }
}
