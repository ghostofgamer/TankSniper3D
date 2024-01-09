using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _minlimitX;
    [SerializeField] private float _maxlimitX;
    [SerializeField] private float _minlimitY;
    [SerializeField] private float _maxlimitY;

    private AimInputButton _aimInputButton;
    private float _speed;
    private Vector3 _targetPosition;
    private Quaternion _targetRotation;

    private void Start()
    {
        _speed = _maxSpeed;
        transform.position = _targetRotation * _offset + _target.position;
        SetStartPosition();
    }

    private void Update()
    {
        if (_aimInputButton.IsZoom)
            _speed = _minSpeed;
        else
            _speed = _maxSpeed;

        if (Input.GetMouseButton(0))
            Rotate();
    }

    public void Init(AimInputButton aimInputButton)
    {
        _aimInputButton = aimInputButton;
    }

    public void Rotate()
    {
        GetData();
        transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, _targetRotation, Time.deltaTime * _speed);
        transform.position = Vector3.SlerpUnclamped(transform.position, _targetPosition, Time.deltaTime * _speed);
    }

    private void SetStartPosition()
    {
        GetData();
        transform.rotation = _targetRotation;
        transform.position = _targetPosition;
    }

    private void GetData()
    {
        _x += Input.GetAxis(MouseX);
        _x = Mathf.Clamp(_x, -_minlimitY, _maxlimitY);
        _y += Input.GetAxis(MouseY);
        _y = Mathf.Clamp(_y, -_minlimitX, _maxlimitX);
        _targetRotation = Quaternion.Euler(-_y, _x, 0f);
        _targetPosition = _targetRotation * _offset + _target.position;
    }
}