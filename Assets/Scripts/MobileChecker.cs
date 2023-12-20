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
    [SerializeField] private CanvasGroup _PC;
    [SerializeField] private CanvasGroup _mobile;
    [SerializeField] private Merge _merge;
    [SerializeField] private BuyTank[] _buyTanks;

    private void Awake()
    {
        if (_isMenu)
        {
            if (Application.isMobilePlatform)
            {
                //_prefabVariant.SetActive(false);
                //_prefamMobileVariant.SetActive(true);
                _mobile.alpha = 1;
                _mobile.interactable = true;
                _mobile.blocksRaycasts = true;
                _PC.gameObject.SetActive(false);
                _merge.Init(_buyTanks[0]);
            }
            else
            {
                _mobile.gameObject.SetActive(false);
                _PC.alpha = 1;
                _PC.interactable = true;
                _PC.blocksRaycasts = true;
                _merge.Init(_buyTanks[1]);
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