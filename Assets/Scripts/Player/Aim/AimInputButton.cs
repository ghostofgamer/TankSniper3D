using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimInputButton : AbstractButton
{
    [SerializeField] private TowerRotates _towerRotatesss;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameObject _imageReload;
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private VisibilityAim _visibilityAim;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private ButtonMover _buttonMover;

    //private Vector3 _startPosition;
    //private Vector3 _target;

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    [SerializeField] private RayTest _rayTest;
    [SerializeField] private ReviewCamera _reviewCamera;
    [SerializeField] private TowerRotate _towerRotate;

    //private void Start()
    //{
    //    _startPosition = transform.position;
    //    //_target = new Vector3(transform.position.x, -160, transform.position.z);
    //    _target = transform.position;
    //}

    private void Update()
    {
        _eventTrigger.enabled = !_imageReload.activeSelf;


        if (!_weapon.IsReload)
        {
            _buttonMover.Move();
            //if (transform.position != _target)
            //    transform.position = Vector3.Lerp(transform.position, _target, 15f * Time.deltaTime);

            if (isPressed)
            {
                IsZoom = true;
                _rayTest.MoveRotate();
                _cameraAim.CameraFovForward();
                //transform.position = Vector3.Lerp(transform.position, _target, 5 * Time.deltaTime);
            }

            if (!isPressed && IsZoom)
            {
                IsZoom = false;
                int randomNumber = Random.Range(0, 2);

                if (_killedInfo.IsLastEnemy && randomNumber == 0)
                {
                    LastShootActivated();
                }
                else
                {
                    _weapon.Shoot();
                    //OnSetCameraPause();
                }

                _buttonMover.ButtonUp();
            }
        }

        if (!IsZoom)
        {
            _towerRotate.ResetRotate();
            _cameraAim.CameraFovBack();
            //transform.position = Vector3.Lerp(transform.position, _startPosition, 1 * Time.deltaTime);
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

    private void OnDown()
    {
        _buttonMover.ButtonDown();
        isPressed = true;
        _playerMover.Go();
        _cameraMover.Forward();
        _visibilityAim.OnFadeIn();
    }

    private void OnUp()
    {
        isPressed = false;
        _playerMover.Hide();
        _cameraMover.Back();
        _visibilityAim.OnFadeOut();
        //NextTarget(160);
    }

    public void LastShootActivated()
    {
        _cameraAim.OnCinemaMachine();
        _weapon.LastShoot();
    }

    //private void NextTarget(float target)
    //{
    //    float step = Mathf.Clamp(transform.position.y + target, -100, 30);
    //    _target = new Vector3(transform.position.x, step, transform.position.z);
    //}
}