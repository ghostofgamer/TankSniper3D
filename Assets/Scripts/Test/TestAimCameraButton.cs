using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestAimCameraButton : MonoBehaviour
{
    [SerializeField] private TowerRotates _towerRotate;
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private PlayerMover _playerMover;
    //[SerializeField] private AimInputButton _aimInputButton;

    [SerializeField] private Camera _camera;

    //[SerializeField] private float _fovTarget;
    [SerializeField] private float _fovStart;
    private float _speed = 1f;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private float _fov;

    public bool isPressed = false;

    [SerializeField] private Weapon _weapon;

    [SerializeField] private Image _aimImage;
    [SerializeField] private Image _startImage;
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private ReviewCamera _reviewCamera;
    [SerializeField] private RayTest _rayTest;
    [SerializeField] private CanvasGroup _canvasGroupe;

    private Coroutine _coroutine;

    private void Update()
    {
        if (isPressed)
        {
            _cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_cinemachineVirtualCamera.m_Lens.FieldOfView, _fov, _speed * Time.deltaTime);
            _rayTest.MoveRotate();
        }
        else
        {
            _cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_cinemachineVirtualCamera.m_Lens.FieldOfView, _fovStart, _speed * Time.deltaTime);
            //_towerRotate.ResetRotate();
        }
    }

    public void OnDown()
    {
        //_camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _fovTarget, _speed * Time.deltaTime);
        //_cinemachineVirtualCamera.m_Lens.FieldOfView = _fov;
        //_cinemachineVirtualCamera.m_Lens.FieldOfView=Mathf.Lerp(_cinemachineVirtualCamera.m_Lens.FieldOfView, _fov, _speed * Time.deltaTime);
        //_reviewCamera.Forward();
        _playerMover.Go();
        isPressed = true;
        //StartCoroutine(FadeOut(_aimImage));
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeIn(_startImage));
    }

    public void OnUp()
    {
        //_camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _fovStart, _speed * Time.deltaTime);
        //_reviewCamera.Back();
        _playerMover.Hide();
        isPressed = false;

        _weapon.Shoot();
        //_weapon.LastShoot();
        //_aimInputButton.LastShootActivated();
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        //StartCoroutine(FadeIn(_aimImage));
        _coroutine =  StartCoroutine(FadeOut(_startImage));
    }

    IEnumerator FadeIn(Image image)
    {
        //float time = 1f;


        while (_canvasGroupe.alpha != 1)
        {
            _canvasGroupe.alpha += 1.5f * Time.deltaTime;
            //image.color.a = image.color.a - 1.5f * Time.deltaTime;
            yield return null;
        }
        //while (time > 0f)
        //{
        //    time -= Time.deltaTime * Time.timeScale;
        //    float a = _curve.Evaluate(time);
        //    image.color = new Color(_aimImage.color.r, _aimImage.color.g, _aimImage.color.b, a);
        //    yield return 0;
        //}
    }

    IEnumerator FadeOut(Image image)
    {
        //float time = 0f;

        while (_canvasGroupe.alpha != 0)
        {
            _canvasGroupe.alpha -= 1.5f * Time.deltaTime;
            yield return null;
        }

        //while (time < 1f)
        //{
        //    time += Time.deltaTime * Time.timeScale;
        //    float alpha = _curve.Evaluate(time);
        //    image.color = new Color(_aimImage.color.r, _aimImage.color.g, _aimImage.color.b, alpha);
        //    yield return 0;
        //}
    }
}
