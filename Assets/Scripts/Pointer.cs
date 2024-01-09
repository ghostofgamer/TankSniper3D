using Assets.Scripts.GameEnemy;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _aim;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Image _arrow;
        [SerializeField] private Transform _lookEnemyPosition;

        private Vector2 _pointerPosition;
        private int _distance = 36;
        private float _speed = 6f;
        private int _maxPrecent = 100;
        private int _half = 2;
        private int _procentX;
        private int _procentY;
        private int _minX;
        private int _maxX;
        private int _minY;
        private int _maxY;
        private int _width;
        private int _height;
        private int _procentWidth = 8;
        private int _procentHeight = 15;
        private int _mobileWidth = 21;
        private int _mobileHeight = 10;

        private void Awake()
        {
            if (Application.isMobilePlatform)
            {
                _procentWidth = _mobileWidth;
                _procentHeight = _mobileHeight;
            }
        }

        private void Start()
        {
            GetParametrsScreen();
        }

        private void Update()
        {
            if (!_enemy.IsDying)
            {
                if (_height != Screen.height || _width != Screen.width)
                    GetParametrsScreen();

                _pointerPosition = Camera.main.WorldToScreenPoint(_target.position);
                _lookEnemyPosition.position = _pointerPosition;
                _pointerPosition.x = Mathf.Clamp(_pointerPosition.x, _minX, _maxX);
                _pointerPosition.y = Mathf.Clamp(_pointerPosition.y, _minY, _maxY);
                _image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, _speed * Time.deltaTime);
                _image.transform.LookAt(_lookEnemyPosition);

                if (Vector3.Distance(_image.transform.position, _lookEnemyPosition.position) < _distance)
                    _arrow.gameObject.SetActive(false);
                else
                    _arrow.gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void GetParametrsScreen()
        {
            _width = Screen.width;
            _height = Screen.height;
            _procentX = _width / _maxPrecent * _procentWidth;
            _procentY = _height / _maxPrecent * _procentHeight;
            _minX = _width / _half - _procentX;
            _maxX = _width / _half + _procentX;
            _minY = _height / _half - _procentY;
            _maxY = _height / _half + _procentY;
        }
    }
}