using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _cameraAim;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TowerRotate _towerRotate;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private bool _isZoom = false;
    private Coroutine _coroutine;

    private void Start()
    {
        _mainCamera.GetComponent<Camera>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!_weapon.IsReload)
        {
            if (_isZoom)
            {
                _towerRotate.Rotate();
            }

            if (!_isZoom)
            {
                _towerRotate.ResetRotate();
            }

            if (Input.GetMouseButtonDown(0))
            {
                SetCamera();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _weapon.Shoot();

                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                _coroutine = StartCoroutine(SetCameraPause());
            }
        }
    }

    private IEnumerator SetCameraPause()
    {
        yield return _waitForSeconds;
        SetCamera();
    }

    private void SetCamera()
    {
        _isZoom = !_isZoom;
        _mainCamera.enabled = !_mainCamera.enabled;
        _cameraAim.enabled = !_mainCamera.enabled;
    }
}
