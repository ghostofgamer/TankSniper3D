using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _x, _y;
    [SerializeField] private Vector3 _offset;
    [Range(0.1f,0.99f)]
    [SerializeField] private float _speed;
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

    private void Start()
    {
        transform.position = targetRot * _offset + target.position;
        WHAT();
        startTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        //{
        //    if (!_isZoomStart)
                RoatteNew();

        //}
        //else
        //{
        //    Stay();
        //}
    }

    public void RoatteNew()
    {

        _x += Input.GetAxis(MouseX);
        _x = Mathf.Clamp(_x, -minlimitY, maxlimitY);
        _y += Input.GetAxis(MouseY);
        _y = Mathf.Clamp(_y, -minlimitX, maxlimitX);

        float fracComplete = (Time.time - startTime) / journeyTime;
        //Debug.Log("Camera " + fracComplete);
        targetRot = Quaternion.Euler(-_y, _x, 0f);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _speed);
        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, fracComplete);
        transform.rotation = NewtargetRot;
        targetPos = targetRot * _offset + target.position;
        //NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);
        NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _speed);
        //NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, fracComplete);
        transform.position = NewTargetPos;
    }

    public void Zoom()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(ZoomChanger());
    }

    private IEnumerator ZoomChanger()
    {
        _isZoomStart = true;
        yield return new WaitForSeconds(0.165f);
        _isZoomStart = false;
    }

    public void Stay()
    {
        NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        transform.rotation = NewtargetRot;
        targetPos = targetRot * _offset + target.position;
        NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);
        transform.position = NewTargetPos;
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