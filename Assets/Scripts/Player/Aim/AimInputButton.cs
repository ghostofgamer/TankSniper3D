using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimInputButton : AbstractButton
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameObject _imageReload;
    [SerializeField] private ReloadSlider _reloadSlider;
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private VisibilityAim _visibilityAim;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private ButtonMover _buttonMover;
    [SerializeField] private HitPoint _hitPoint;
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private CancelShoot _cancelShoot;

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    private void Update()
    {
        if (_killedInfo.AllDie)
        {
            _eventTrigger.enabled = false;
        }

        //_eventTrigger.enabled = !_imageReload.activeSelf;
        _eventTrigger.enabled = !_reloadSlider.gameObject.activeSelf;

        if (!_weapon.IsReload)
        {
            //_buttonMover.Move();
            //if (!_killedInfo.AllDie)
            if (isPressed)
            {
                DoZoom();
            }
        }

        if (!isPressed && IsZoom)
        {
            DoShoot();
        }

        if (!IsZoom || _weapon.IsReload)
        {
            _towerRotate.ResetRotate();
            _cameraAim.CameraFovBack();
        }
    }

    public override void OnClick()
    {
    }

    public void Init(Weapon weapon, TowerRotate towerRotate, CameraAim cameraAim, PlayerMover playerMover)
    {
        _weapon = weapon;
        _towerRotate = towerRotate;
        _cameraAim = cameraAim;
        _playerMover = playerMover;
    }

    private void DoZoom()
    {
        //IsZoom = true;
        _hitPoint.MoveRotate();
        _cameraAim.CameraFovForward();
    }

    private void DoShoot()
    {
        StartCoroutine(PauseZoomOff());
        //_weapon.Shoot();
        //_buttonMover.Up();
        //IsZoom = false;
    }

    private void OnDown()
    {
        IsZoom = true;
        _buttonMover.Down();
        isPressed = true;
        _playerMover.Go();
        //_cameraMover.Forward();
        _visibilityAim.OnFadeIn();
        _cancelShoot.gameObject.SetActive(true);
    }

    private void OnUp()
    {
        ReturnHide();

        if (!_cancelShoot.IsCancelShoot && !_playerMover.GetComponent<Player>().IsDead)
        {
            _weapon.Shoot();
        }
        //else
        //{
        //    Debug.Log("хочу стрелять");
        //    //IsZoom = false;
        //    isPressed = false;
        //    _playerMover.Hide();
        //    //_cameraMover.Back();
        //    _visibilityAim.OnFadeOut();

        //}
        _cancelShoot.gameObject.SetActive(false);
    }

    public void LastShootActivated()
    {
        _cameraAim.OnCinemaMachine();
        _weapon.LastShoot();
    }

    private IEnumerator PauseZoomOff()
    {
        yield return new WaitForSeconds(0.65f);
        _buttonMover.Up();
        IsZoom = false;
    }

    public void ReturnHide()
    {
        isPressed = false;
        _playerMover.Hide();
        _visibilityAim.OnFadeOut();
    }
}