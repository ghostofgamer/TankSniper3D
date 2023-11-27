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

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis(MouseX);
            float mouseY = Input.GetAxis(MouseY);

            _xRotation -= Input.GetAxis(MouseY);
            _xRotation = Mathf.Clamp(_xRotation, -_minLimitAnglesY, _limitAnglesY);
            _yRotation -= Input.GetAxis(MouseX);
            _yRotation = Mathf.Clamp(_yRotation, -_minLimitAngles, _limitAngles);

            Quaternion targetRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }
    }
}
