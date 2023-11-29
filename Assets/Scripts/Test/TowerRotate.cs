using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private Transform _startTransform;

    private readonly float _speed = 1f;

    private void Start()
    {
            
    }

    public void Rotate(Vector3 target)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;

        Debug.DrawRay(transform.position, forward, Color.red);
        //transform.LookAt(target);
        _tower.transform.LookAt(target);
    }

    public void ResetRotate()
    {
        if (_tower.transform.rotation != _startTransform.rotation)
            _tower.transform.rotation = Quaternion.Lerp(_tower.transform.rotation, _startTransform.rotation, _speed * Time.deltaTime);
    }
}
