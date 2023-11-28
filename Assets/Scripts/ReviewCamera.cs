using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    [SerializeField] private float _limitAngles = 50f;
    [SerializeField] private float _minLimitAngles = 50f;
    [SerializeField] private float _limitAnglesY = 30f;
    [SerializeField] private float _minLimitAnglesY = 30f;

    private Vector3 _target;

    private void Start()
    {
        _target = transform.position;
    }


    private void Update()
    {
        if (transform.position != _target)
            transform.position = Vector3.MoveTowards(transform.position, _target, 16.5f * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            _xRotation -= Input.GetAxis(MouseY);
            _xRotation = Mathf.Clamp(_xRotation, -_minLimitAnglesY, _limitAnglesY);
            _yRotation -= Input.GetAxis(MouseX);
            _yRotation = Mathf.Clamp(_yRotation, -_minLimitAngles, _limitAngles);

            Quaternion targetRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);
            //float mouseX = Input.GetAxis(MouseX);
            //float mouseY = Input.GetAxis(MouseY);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);
        }
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
