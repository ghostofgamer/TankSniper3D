using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour
{
    [SerializeField] private Image[] _hits;
    [SerializeField] private GameObject _positionEnemy;

    private Player _player;
    private int _half = 2;

    private void OnEnable()
    {
        _player.Hit += HitView;
    }

    private void OnDisable()
    {
        _player.Hit -= HitView;
    }

    public void Init(Player player)
    {
        _player = player;
    }

    private void HitView(Transform transform)
    {
        _positionEnemy.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        int widht = Screen.width / _half;
        int height = Screen.height / _half;
        Vector2 center = new Vector2(widht, height);

        if (_positionEnemy.transform.position.x > center.x)
            _hits[0].gameObject.SetActive(true);

        if (_positionEnemy.transform.position.x < center.x)
            _hits[1].gameObject.SetActive(true);

        if (_positionEnemy.transform.position.y > center.y)
            _hits[2].gameObject.SetActive(true);

        if (_positionEnemy.transform.position.y < center.y)
            _hits[3].gameObject.SetActive(true);
    }
}