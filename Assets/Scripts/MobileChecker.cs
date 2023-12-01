using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    //[SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private float _fov;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            //if (_cinemachineVirtualCamera != null)
            //    _cinemachineVirtualCamera.m_Lens.FieldOfView = _fov;

            //if (_camera != null)
                _camera.fieldOfView = _fov;
        }
        else
            return;
    }
}
