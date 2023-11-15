using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimInputButton : AbstractButton
{
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;
    //[SerializeField] private EventTrigger _eventTrigger;

    private Coroutine _coroutine;
    //private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    private void Update()
    {
        if (!_weapon.IsReload)
        {
            if (isPressed)
            {
                _towerRotate.Rotate();
                IsZoom = true;
            }

            if (!isPressed && IsZoom)
            {
                IsZoom = false;
                //StartCoroutine(EnabledTrigger());

                if (_weapon.IsLastShoot)
                {
                    _cameraAim.SetCinemachineCamera();
                    _weapon.LastShoot();
                    OnSetCameraPause();
                }
                else
                {
                    _weapon.Shoot();
                    OnSetCameraPause();
                }
            }
        }

        if (!IsZoom)
            _towerRotate.ResetRotate();
    }

    private void OnSetCameraPause()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    }

    public override void OnClick()
    {
    }

    public void OnDown()
    {
        _playerMover.Go();
        _cameraAim.SetCamera();
        isPressed = true;
        //SetEnabled(false);
    }

    public void OnUp()
    {
        isPressed = false;
        _playerMover.Hide();
        //StartCoroutine(EnabledTrigger());
    }

    public void Init(Weapon weapon, TowerRotate towerRotate, CameraAim cameraAim)
    {
        _weapon = weapon;
        _towerRotate = towerRotate;
        _cameraAim = cameraAim;
    }

    //private void SetEnabled(bool flag)
    //{
    //    _eventTrigger.enabled = flag;
    //}

    //private IEnumerator EnabledTrigger()
    //{
    //    SetEnabled(false);
    //    yield return _waitForSeconds;
    //    SetEnabled(true);
    //}
}