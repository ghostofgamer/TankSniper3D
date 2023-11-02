using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _cameraAim;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void Start()
    {
        _mainCamera.GetComponent<Camera>();
        _mainCamera = Camera.main;
    }

    public IEnumerator SetCameraPause()
    {
        yield return _waitForSeconds;
        SetCamera();
    }

    public void SetCamera()
    {
        _mainCamera.enabled = !_mainCamera.enabled;
        _cameraAim.enabled = !_mainCamera.enabled;
    }
}
