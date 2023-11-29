using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Vector3 _target;

    private void Start()
    {
        _target = transform.position;
    }

    private void Update()
    {
        if (transform.position != _target)
            transform.position = Vector3.MoveTowards(transform.position, _target, 16.5f * Time.deltaTime);
    }

    private void SetNextPosition(float step)
    {
        _target = new Vector3(_target.x, _target.y, _target.z + step);
    }

    public void Forward()
    {
        SetNextPosition(10);
    }

    public void Back()
    {
        SetNextPosition(-10);
    }
}
