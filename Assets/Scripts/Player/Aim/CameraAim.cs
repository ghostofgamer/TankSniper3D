using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAim : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _cineMachineCamera;
    [SerializeField] private float _fov;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private float _fovStart;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private float _speed = 10f;
    private VisibilityAim _visibilityAim;
    private AimInputButton _aimInputButton;

    private void Start()
    {
        _fovStart = _mainCamera.fieldOfView;
        _startPosition = _mainCamera.transform.position;
        _startRotation = _mainCamera.transform.rotation;
    }

    public void Init(AimInputButton aimInputButton, VisibilityAim visibilityAim)
    {
        _aimInputButton = aimInputButton;
        _visibilityAim = visibilityAim;
    }

    public void PlayCinemachine()
    {
        StartCoroutine(ChangerCinemaMachine());
    }

    public void CinemachineMove(Bullet bullet)
    {
        _cineMachineCamera.transform.parent = null;
        _cineMachineCamera.Follow = bullet.transform;
        _cineMachineCamera.LookAt = bullet.transform;
    }

    public void CameraFovForward()
    {
        CameraFovChanged(_fov);
    }

    public void CameraFovBack()
    {
        CameraFovChanged(_fovStart);
    }

    private void OnCinemachine()
    {
        SetCinemachine(true);
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
    }

    private void SetCinemachine(bool flag)
    {
        _aimInputButton.enabled = !flag;
        _cineMachineCamera.gameObject.SetActive(flag);
    }

    private void OffCinemachine()
    {
        SetCinemachine(false);
        ResetMainCamera();
        Time.timeScale = 1f;
    }

    private void CameraFovChanged(float target)
    {
        _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, target, _speed * Time.deltaTime);
    }

    private IEnumerator ChangerCinemaMachine()
    {
        OnCinemachine();
        _visibilityAim.OffCanvasActive();
        yield return _waitForSeconds;
        OffCinemachine();
    }

    private void ResetMainCamera()
    {
        _mainCamera.transform.rotation = _startRotation;
        _mainCamera.transform.position = _startPosition;
    }
}