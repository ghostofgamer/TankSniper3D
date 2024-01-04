using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    private Weapon _weapon;

    public event UnityAction AlarmChanged;

    public void Init(Weapon weapon)
    {
        _weapon = weapon;
    }

    private void OnEnable()
    {
        _weapon.FirstShoot += SetAlarm;
    }

    private void OnDisable()
    {
        _weapon.FirstShoot -= SetAlarm;
    }

    private void SetAlarm()
    {
        AlarmChanged?.Invoke();
    }
}