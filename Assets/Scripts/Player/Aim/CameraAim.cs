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
    private Quaternion _startRotation;

    private void Start()
    {
        _startPosition = _mainCamera.transform.position;
        _startRotation = _mainCamera.transform.rotation;
        _mainCamera.GetComponent<Camera>();
        _mainCamera = Camera.main;
    }

    public IEnumerator SetCameraPause()
    {
        yield return _waitForSeconds;
        //SetCamera();
        OffCinemachineCamera();
    }

    public void SetCamera()
    {
        _mainCamera.enabled = !_mainCamera.enabled;
        _cameraAim.enabled = !_mainCamera.enabled;
    }

    public void SetCinemachinecamera()
    {
        _cinemachinecamera.GetComponent<Camera>().enabled = true;
        _cinemachinecamera.enabled = true;
        _mainCamera.enabled = false;
        _cameraAim.enabled = false;
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }
    public void OffCinemachineCamera()
    {
        _cinemachinecamera.GetComponent<Camera>().enabled = !_cinemachinecamera.GetComponent<Camera>().enabled;
        _cinemachinecamera.enabled = false;
        ReserMainCamera();
        _mainCamera.enabled = true;
        _cameraAim.enabled = false;
        Time.timeScale = 1f;
    }

    private void ReserMainCamera()
    {
        _mainCamera.transform.rotation = _startRotation;
        _mainCamera.transform.position = _startPosition;
    }
}
