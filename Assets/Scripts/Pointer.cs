using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public Transform other;

    [SerializeField] private Image _image;
    private Vector2 _pointerPosition;
    [SerializeField] private GameObject _aim;


    [SerializeField] private Enemy _enemy;

    [SerializeField] private Image _imageCurrent;
    [Range(100, 100000)]
    [SerializeField] private int _range;

    [SerializeField] private Image _newImage;

    private Vector2[] _pointerPositions;

    private void Update()
    {
        if (!_enemy.IsDying)
        {
            _pointerPosition = Camera.main.WorldToScreenPoint(_target.position);
            //_imageCurrent.transform.position = Camera.main.WorldToScreenPoint(_target.position);
            _imageCurrent.transform.position = _pointerPosition;

            _pointerPosition.x = Mathf.Clamp(_pointerPosition.x, /*Screen.width+ _range*/_aim.transform.position.x - 145f /*ProcentLeft*/, /*ProcentRight*/ _aim.transform.position.x + 145f /*Screen.width - _range*/);
            _pointerPosition.y = Mathf.Clamp(_pointerPosition.y, _aim.transform.position.y - 145f, _aim.transform.position.y + 145f/*Screen.height - 55f*/);

            //_image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, 6 * Time.deltaTime);
            _image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, 6 * Time.deltaTime);
            _image.transform.LookAt(_imageCurrent.transform);

            if(Vector3.Distance(_image.transform.position, _imageCurrent.transform.position) < 90)
            {
                _newImage.gameObject.SetActive(false);
            }
            else
            {
                _newImage.gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private Quaternion GetIconRotation(int planeIndex)
    {
        if (planeIndex == 0)
            return Quaternion.Euler(0f, 0f, 90f);

        if (planeIndex == 1)
            return Quaternion.Euler(0f, 0f, -90f);

        if (planeIndex == 2)
            return Quaternion.Euler(0f, 0f, 180f);

        if (planeIndex == 3)
            return Quaternion.Euler(0f, 0f, 0f);

        return Quaternion.identity;
    }
}