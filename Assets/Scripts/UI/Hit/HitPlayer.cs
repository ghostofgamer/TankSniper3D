using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _aim;
    [SerializeField] private Image[] _hits;
    [SerializeField] private GameObject _imageCurrent;
    private Vector2 _pointerPosition;

    private void OnEnable()
    {
        _player.Hit += HitView;
    }

    private void OnDisable()
    {
        _player.Hit -= HitView;
    }

    private void HitView(Transform transform)
    {
        _pointerPosition = Camera.main.WorldToScreenPoint(transform.position);
        _imageCurrent.transform.position = _pointerPosition;
        //Debug.Log("Aim " + _aim.transform.position.x);
        int widht = Screen.width / 2;
        int height = Screen.height / 2;

        Vector2 center = new Vector2(widht, height);
        Debug.Log("Aim " + center.x);


        if (_imageCurrent.transform.position.x > center.x)
        {
            _hits[0].gameObject.SetActive(true);
        }
        if (_imageCurrent.transform.position.x < center.x)
        {
            _hits[1].gameObject.SetActive(true);
        }
        if (_imageCurrent.transform.position.y > center.y)
        {
            _hits[2].gameObject.SetActive(true);
        }

        //if (transform.position.x > _player.transform.position.x)
        //    _hits[0].gameObject.SetActive(true);

        //if (transform.position.x < _player.transform.position.x)
        //    _hits[1].gameObject.SetActive(true);

        //if (transform.position.y > _player.transform.position.y)
        //    _hits[2].gameObject.SetActive(true);
    }
}