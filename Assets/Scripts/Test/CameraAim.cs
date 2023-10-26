using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Image _zoom;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _cameraAim;
    [SerializeField] private Weapon _weapon;


    private void Start()
    {
        _mainCamera.GetComponent<Camera>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetCamera();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetCamera();
            _weapon.Shoot();
        }
    }

    private void SetCamera()
    {
        _mainCamera.enabled = !_mainCamera.enabled;
        _cameraAim.enabled = !_mainCamera.enabled;
    }
}
