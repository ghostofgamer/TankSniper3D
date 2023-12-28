using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _x, _y;
    [SerializeField] private Vector3 _offset;
    //[Range(0.01f, 0.99f)]
    private float _speed;
    [SerializeField]private float _maxSpeed;
    [SerializeField]private float _minSpeed;
    [Range(0.01f, 99f)]
    [SerializeField] private float _speedTime = 3f;
    [SerializeField] private Transform target;

    private AimInputButton _aimInputButton;
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
        _speed = _maxSpeed;
        transform.position = targetRot * _offset + target.position;
        WHAT();
        startTime = Time.time;
    }
    private void Update()
    {
        if (_aimInputButton.IsZoom)
        {
            _speed = _minSpeed;
        }
        else
        {
            _speed = _maxSpeed;
        }

        if (Input.GetMouseButton(0))
            RoatteNew();
    }

    public void Init(AimInputButton aimInputButton)
    {
        _aimInputButton = aimInputButton;
    }

    public void RoatteNew()
    {
        _x += Input.GetAxis(MouseX);
        _x = Mathf.Clamp(_x, -minlimitY, maxlimitY);
        _y += Input.GetAxis(MouseY);
        _y = Mathf.Clamp(_y, -minlimitX, maxlimitX);
        float fracComplete = (Time.time - startTime) / journeyTime;
        targetRot = Quaternion.Euler(-_y, _x, 0f);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        //NewtargetRot = Quaternion.Lerp(transform.rotation, targetRot, _speed);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _speed);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, fracComplete);
        //transform.rotation = NewtargetRot;
        targetPos = targetRot * _offset + target.position;


        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _time);
        transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, targetRot, Time.deltaTime * _speed);
        _time += Time.deltaTime * _speed;
        //transform.position = Vector3.Slerp(transform.position, targetPos, _time);
        transform.position = Vector3.SlerpUnclamped(transform.position, targetPos, Time.deltaTime * _speed);
        //Debug.Log(_time);
        //Debug.Log(_speed);
        //while (time < 1)
        //{
        //    //transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, time);
        //    //transform.position = Vector3.Lerp(transform.position, targetPos, time);
        //    time += Time.deltaTime * _speedTime;
        //    Debug.Log("TIME " + time);
        //    Debug.Log("Delta " + Time.deltaTime);
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