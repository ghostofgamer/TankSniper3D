using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public bool Warning { get; private set; } = false;

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
