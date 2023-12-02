using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Vector3 _target;
    private float _speed = 60f;
    private float _step = 10;

    private void Start()
    {
        _target = transform.position;
    }

    //private void Update()
    //{
    //    if (transform.position != _target)
    //        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    //}

    private void SetNextPosition(float step)
    {
        _target = new Vector3(_target.x, _target.y, _target.z + step);
    }

    public void Forward()
    {
        SetNextPosition(_step);
    }

    public void Back()
    {
        SetNextPosition(-_step);
    }

    public void GOGOGO()
    {
        transform.position = transform.forward * 10f;
    }
}
