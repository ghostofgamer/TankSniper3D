using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _limitAngles = 50f;
    [SerializeField] private float _minLimitAngles = 50f;
    [SerializeField] private float _limitAnglesY = 30f;
    [SerializeField] private float _minLimitAnglesY = 30f;

    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        _xRotation = transform.rotation.y;
        _yRotation = transform.rotation.x;
        //Input.GetAxis(MouseY) = transform.rotation.x;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rotate();
        }
    }

    public void Rotate()
    {
        _xRotation -= Input.GetAxis(MouseY)/* * 5*/;
        Debug.Log(_xRotation);
        _xRotation = Mathf.Clamp(_xRotation, -_minLimitAnglesY, _limitAnglesY);
        _yRotation -= Input.GetAxis(MouseX)/* * 5*/;
        _yRotation = Mathf.Clamp(_yRotation, -_minLimitAngles, _limitAngles);

        Quaternion targetRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 130 * Time.deltaTime);
    }
}