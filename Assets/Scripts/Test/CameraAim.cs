using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim: MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Image _zoom;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _startPosition;

    private bool _isZoom = false;

    private void Start()
    {
        _startPosition = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isZoom = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isZoom = false;
        }

        if (_isZoom)
        {
            _zoom.gameObject.SetActive(true);
            _camera.fieldOfView = 30;
            _camera.transform.position = _transform.position;
            //_camera.transform.rotation = new Quaternion(_transform.rotation.x, _transform.rotation.y, _transform.rotation.z, 1);
            _camera.transform.rotation = _transform.rotation;
        }
        else
        {
            _camera.transform.position = _startPosition.position;
            _camera.transform.rotation = _startPosition.rotation;
            _zoom.gameObject.SetActive(false);
            _camera.fieldOfView = 100;
        }
    }
}
