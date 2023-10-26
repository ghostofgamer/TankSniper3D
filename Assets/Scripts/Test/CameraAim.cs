using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Image _zoom;
    [SerializeField] private Camera _camera;
    [SerializeField] private Camera _camera2;
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Weapon _weapon;

    private bool _isZoom = false;

    private void Start()
    {
        _camera.GetComponent<Camera>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetCamera();
            _isZoom = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetCamera();
            _isZoom = false;
            _weapon.Shoot();
        }

        //if (_camera2.enabled)
        //{
        //    //float vertical = Input.GetAxis("Mouse Y");
        //    //float horizontal = Input.GetAxis("Mouse X");
        //    //_zoom.gameObject.SetActive(true);
        //    //_camera2.fieldOfView = 30;

        //    //_camera2.transform.position = _transform.position;
        //    //transform.rotation *= Quaternion.Euler(vertical, horizontal, 0);

        //    //_camera2.transform.rotation = _transform.rotation;
        //}
        //else
        //{
        //    _zoom.gameObject.SetActive(false);
        //    //_camera2.fieldOfView = 60;
        //}

    }
    private void SetCamera()
    {
        _camera.enabled = !_camera.enabled;
        _camera2.enabled = !_camera.enabled;
    }
}
