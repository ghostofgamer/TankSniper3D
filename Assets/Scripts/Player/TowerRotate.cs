using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    [SerializeField] private Transform _startTransform;
    [SerializeField] private GameObject _tower;

    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _limitAngles = 50f;
    [SerializeField] private float _minLimitAngles = 50f;
    [SerializeField] private float _limitAnglesY = 30f;
    [SerializeField] private float _minLimitAnglesY = 30f;

    private readonly float _speed = 1f;

    private float vertical;
    private float horizontal;

    private float _sensivity = 15;
    private float _xRotation = 0f;
    private float _yRotation = 0f;

    private float _speedSlerp = 1.65f;

    public void Rotate()
    {
        float mouseX = Input.GetAxis(MouseX)/* * _sensivity*/ /** Time.deltaTime*/;
        float mouseY = Input.GetAxis(MouseY) /** _sensivity*/ /** Time.deltaTime*/;

        _xRotation -= Input.GetAxis(MouseY)/*mouseY*/;
        _xRotation = Mathf.Clamp(_xRotation, -_minLimitAnglesY, _limitAnglesY);
        _yRotation -= Input.GetAxis(MouseX) /*mouseX*/;
        _yRotation = Mathf.Clamp(_yRotation, -_minLimitAngles, _limitAngles);

        //transform.localRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);

        Quaternion targetRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);





        //Quaternion targetRotation = Quaternion.Euler(
        //    Mathf.Clamp(_xRotation, -_limitAnglesY, _limitAnglesY),
        //    Mathf.Clamp(-_yRotation, -_limitAngles, _limitAngles), 0);






        Vector3 finalRotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedSlerp * Time.deltaTime).eulerAngles;


        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 60 * Time.deltaTime);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedSlerp * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);




        //transform.rotation = Quaternion.Euler(finalRotation);

        //transform.rotation = Quaternion.Euler(
        //    Mathf.Clamp(_xRotation, -_limitAngles, _limitAngles),
        //    Mathf.Clamp(-_yRotation, -_limitAngles, _limitAngles), 0);

        //vertical += Input.GetAxis(s_MouseY);
        //horizontal += Input.GetAxis(s_MouseX);
        //transform.rotation = Quaternion.Euler(
        //    Mathf.Clamp(-vertical * Time.deltaTime, -_limitAngles, _limitAngles), 
        //    Mathf.Clamp(horizontal * Time.deltaTime, -_limitAngles, _limitAngles), 0);
    }

    public void ResetRotate()
    {
        if (_tower.transform.rotation != _startTransform.rotation)
            transform.rotation = Quaternion.Lerp(transform.rotation, _startTransform.rotation, _speed * Time.deltaTime);
    }
}
