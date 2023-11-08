using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private Weapon _weapon;

    public bool Warning { get; private set; } = false;

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
        Warning = true;
    }
}
