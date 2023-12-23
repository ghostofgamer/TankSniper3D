using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTestMove : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _x, _y;
    [SerializeField] private Vector3 _offset;
    //[Range(0.01f, 0.99f)]
    [SerializeField] private float _speed = 0.05f;
    [Range(0.01f, 99f)]
    [SerializeField] private float _speedTime = 3f;
    public Transform target;
    public float minlimitX = 80;
    public float maxlimitX = 80;
    public float minlimitY = 80;
    public float maxlimitY = 80;

    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private bool _isZoomStart = false;
    private Coroutine coroutine;
    Vector3 targetPos;
    Vector3 NewTargetPos;
    Quaternion targetRot;
    Quaternion NewtargetRot;

    private float startTime;
    public float journeyTime = 1f;

    private float _time = 0;
    private void Start()
    {
        transform.position = targetRot * _offset + target.position;
        WHAT();
        startTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            RoatteNew();
        else
        _time = 0;
            //{
            //    if (!_isZoomStart)

        //}
        //else
        //{
        //    Stay();
        //}
    }

    public void RoatteNew()
    {

        _x += Input.GetAxis(MouseX)/* * Time.deltaTime*_speedTime*/;
        _x = Mathf.Clamp(_x, -minlimitY, maxlimitY);
        _y += Input.GetAxis(MouseY)/* * Time.deltaTime*_speedTime*/;
        _y = Mathf.Clamp(_y, -minlimitX, maxlimitX);

        float fracComplete = (Time.time - startTime) / journeyTime;
        //Debug.Log("Camera " + fracComplete);
        targetRot = Quaternion.Euler(-_y, _x, 0f);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        //NewtargetRot = Quaternion.Lerp(transform.rotation, targetRot, _speed);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _speed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _speed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _speedTime);
        //Debug.Log(_speed);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, fracComplete);
        //transform.rotation = NewtargetRot;
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, time);
        targetPos = targetRot * _offset + target.position;

        float time = 0;

        //while (time < 1)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _time);
        //    time += Time.deltaTime * _speed;
        //    transform.position = Vector3.Slerp(transform.position, targetPos, _time);
        //    Debug.Log("TIME " + time);
        //}

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _time);
        _time += Time.deltaTime * _speed;
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, time);
        transform.position = Vector3.Slerp(transform.position, targetPos, _time);

        //transform.position = Vector3.Lerp(transform.position, targetPos, time);

        //Debug.Log("TIME " + _time);
        //Debug.Log("Delta " + Time.deltaTime);
        //}

        //NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);
        //NewTargetPos = Vector3.Lerp(transform.position, /*transform.localRotation*/targetPos, _speed);
        //NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _speed);
        //NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, fracComplete);
        //transform.position = NewTargetPos;
    }

    private void WHAT()
    {
        _x += Input.GetAxis(MouseX);
        _x = Mathf.Clamp(_x, -minlimitY, maxlimitY);
        _y += Input.GetAxis(MouseY);
        _y = Mathf.Clamp(_y, -minlimitX, maxlimitX);
        targetRot = Quaternion.Euler(-_y, _x, 0f);
        NewtargetRot = targetRot;
        transform.rotation = NewtargetRot;
        targetPos = targetRot * _offset + target.position;
        NewTargetPos = targetPos;
        transform.position = targetPos;
    }
}
