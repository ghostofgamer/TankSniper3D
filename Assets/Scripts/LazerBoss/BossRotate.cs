using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private Player _player;
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Transform _muzzlePoint;

    private bool _isAlarm = false;

    private void OnEnable()
    {
        _alarm.AlertChanged += OnAlarm;
    }

    private void OnDisable()
    {
        _alarm.AlertChanged -= OnAlarm;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_isAlarm == true)
        {
            _tower.transform.LookAt(_player.transform.position);
            _muzzlePoint.transform.LookAt(_player.transform.position);
        }

        _tower.transform.Rotate(0, 1, 0);
    }

    private void OnAlarm()
    {
        _isAlarm = true;
    }
}