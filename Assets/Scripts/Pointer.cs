using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _aim;
    [SerializeField] private Enemy _enemy;
    //[SerializeField] private Image _lookEnemy;
    [SerializeField] private Image _arrow;
    [SerializeField] private Transform _lookEnemyPosition;
    
    private Vector2 _pointerPosition;
    private int _procentX;
    private int _procentY; 
    private int _minX;
    private int _maxX;
    private int _minY;
    private int _maxY;
    private int _width;
    private int _height;

    private void Start()
    {
        GetParametrsScreen();
    }

    private void Update()
    {
        if (!_enemy.IsDying)
        {
            if (_height != Screen.height || _width != Screen.width)
            {
                GetParametrsScreen();
            }

            _pointerPosition = Camera.main.WorldToScreenPoint(_target.position);
            //_imageCurrent.transform.position = Camera.main.WorldToScreenPoint(_target.position);
            //_lookEnemy.transform.position = _pointerPosition;
            _lookEnemyPosition.position = _pointerPosition;

            _pointerPosition.x = Mathf.Clamp(_pointerPosition.x,/*_aim.transform.position.x - 145f*/_minX, _maxX/* _aim.transform.position.x + 145f*/ /*Screen.width - _range*/);
            _pointerPosition.y = Mathf.Clamp(_pointerPosition.y, _minY /*_aim.transform.position.y - 145f*/, _maxY/*_aim.transform.position.y + 145f*//*Screen.height - 55f*/);

            _image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, 6 * Time.deltaTime);
            _image.transform.LookAt(_lookEnemyPosition);

            if (Vector3.Distance(_image.transform.position, _lookEnemyPosition.position) < 36)
            {
                _arrow.gameObject.SetActive(false);
            }
            else
            {
                _arrow.gameObject.SetActive(true);
            }
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
        _procentX = _width / 100 * 8;
        _procentY = _height / 100 * 15;
        _minX = _width / 2 - _procentX;
        _maxX = _width / 2 + _procentX;
        _minY = _height / 2 - _procentY;
        _maxY = _height / 2 + _procentY;
    }
}