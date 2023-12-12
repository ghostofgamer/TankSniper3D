using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    //[SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private float _fov;
    [SerializeField] private GameObject _prefabVariant;
    [SerializeField] private GameObject _prefamMobileVariant;
    [SerializeField] private bool _isMenu;

    private void Awake()
    {
        if (_isMenu)
        {
            if (Application.isMobilePlatform)
            {
                _prefabVariant.SetActive(false);
                _prefamMobileVariant.SetActive(true);
            }
        }

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
