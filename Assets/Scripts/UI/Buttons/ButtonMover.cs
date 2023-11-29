using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMover : MonoBehaviour
{
    private Vector3 _target;
    private float _step = 160f;
    private float _speed = 16.5f;
    private float _min = -100;
    private float _max = 30;

    private void Start()
    {
        _target = transform.position;
    }

    public void ButtonUp()
    {
        NextTarget(_step);
    }

    public void ButtonDown()
    {
        NextTarget(-_step);
    }

    public void Move()
    {
        if (transform.position != _target)
            transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
    }

    private void NextTarget(float target)
    {
        float step = Mathf.Clamp(transform.position.y + target, _min, _max);
        _target = new Vector3(transform.position.x, step, transform.position.z);
    }
}
