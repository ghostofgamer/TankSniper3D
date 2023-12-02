using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [Header("Прицел")]
    [SerializeField] private Camera _mainCamera;
    //[SerializeField] private Camera _cameraAim;
    [SerializeField] private CinemachineVirtualCamera _cineMachineCamera;
    [SerializeField] private float _fovStart;
    [SerializeField] private float _fov;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private float _speed = 10f;

    [SerializeField] private AimInputButton _aimInputButton;

    private void Start()
    {
        _fovStart = _mainCamera.fieldOfView;
        _startPosition = _mainCamera.transform.position;
        _startRotation = _mainCamera.transform.rotation;
    }

    //public IEnumerator SetCameraPause()
    //{
    //    yield return _waitForSeconds;
    //    STOPRes();
    //}

    //public void SetCamera()
    //{
    //    _mainCamera.enabled = !_mainCamera.enabled;
    //    _cameraAim.enabled = !_mainCamera.enabled;
    //}

    //public void SetCinemachineCamera()
    //{
    //    _cineMachineCamera.GetComponent<Camera>().enabled = true;
    //    _cineMachineCamera.enabled = true;
    //    _mainCamera.enabled = false;
    //    _cameraAim.enabled = false;
    //    Time.timeScale = 0.3f;
    //    Time.fixedDeltaTime = Time.timeScale * 0.01f;
    //}
    //public void OffCinemachineCamera()
    //{
    //    _cineMachineCamera.GetComponent<Camera>().enabled = false;
    //    _cineMachineCamera.enabled = false;
    //    ResetMainCamera();
    //    _mainCamera.enabled = true;
    //    _cameraAim.enabled = false;
    //    Time.timeScale = 1f;
    //}
    public void OnCinemaMachine()
    {
        StartCoroutine(ChangerCinemaMachine());
    }

    private IEnumerator ChangerCinemaMachine()
    {
        SetCinCamera();
        yield return _waitForSeconds;
        STOPRes();
    }

    private void ResetMainCamera()
    {
        _mainCamera.transform.rotation = _startRotation;
        _mainCamera.transform.position = _startPosition;
    }

    public void SetCinCamera()
    {
        //_aimInputButton.gameObject.SetActive(false);
        _aimInputButton.enabled=false;
        _cineMachineCamera.gameObject.SetActive(true);
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }

    public void CinemachineMove(Bullet bullet)
    {
        _cineMachineCamera.transform.parent = null;
        _cineMachineCamera.Follow = bullet.transform;
        _cineMachineCamera.LookAt = bullet.transform;
    }

    public void STOPRes()
    {
        //_aimInputButton.gameObject.SetActive(true);
        _aimInputButton.enabled=true;
        _cineMachineCamera.gameObject.SetActive(false);
        ResetMainCamera();
        Time.timeScale = 1f;
    }

    private void CameraFovChanged(float target)
    {
        //_cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_cinemachineVirtualCamera.m_Lens.FieldOfView, target, _speed * Time.deltaTime);
        _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, target, _speed * Time.deltaTime);
    }

    public void CameraFovForward()
    {
        CameraFovChanged(_fov);
    }

    public void CameraFovBack()
    {
        CameraFovChanged(_fovStart);
    }
}