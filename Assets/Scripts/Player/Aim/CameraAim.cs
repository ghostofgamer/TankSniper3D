using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _cameraAim;
    [SerializeField] private CinemachineVirtualCamera _cinemachinecamera;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private Vector3 _startPosition;
    private Transform _start;
    private Quaternion _s;

    private void Start()
    {
        _startPosition = _mainCamera.transform.position;
        _s = _mainCamera.transform.rotation;
        _start = _mainCamera.transform;
        _mainCamera.GetComponent<Camera>();
        _mainCamera = Camera.main;
    }

    public IEnumerator SetCameraPause()
    {
        yield return _waitForSeconds;
        //SetCamera();
        OFFCinemachinecamera();
    }

    public void SetCamera()
    {
        _mainCamera.enabled = !_mainCamera.enabled;
        _cameraAim.enabled = !_mainCamera.enabled;
    }

    public void SetCinemachinecamera()
    {
        //_startPosition = _cinemachinecamera.transform.position;
        _cinemachinecamera.GetComponent<Camera>().enabled = true;
        _cinemachinecamera.enabled = true;
        _mainCamera.enabled = false;
        _cameraAim.enabled = false;
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    public void OFFCinemachinecamera()
    {
        _cinemachinecamera.GetComponent<Camera>().enabled = !_cinemachinecamera.GetComponent<Camera>().enabled;
        //_cinemachinecamera.transform.position= _startPosition;
        _cinemachinecamera.enabled = false;
        _mainCamera.transform.rotation = _s;
        _mainCamera.transform.position = _startPosition;
        _mainCamera.enabled = true;
        _cameraAim.enabled = false;
        Time.timeScale = 1f;
    }
}
