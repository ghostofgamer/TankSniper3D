using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScreen : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private ResetButton _resetButton;
    [SerializeField] private PlayerHealthbar _playerHealthbar;

    private Weapon _weapon;

    private void OnEnable()
    {
        _weapon.FirstShoot += OnFirstShootAlarm;
    }

    private void OnDisable()
    {
        _weapon.FirstShoot -= OnFirstShootAlarm;
    }

    public void Init(Weapon weapon)
    {
        _weapon = weapon;
    }

    private void OnFirstShootAlarm()
    {
        _wallet.gameObject.SetActive(false);
        _killedInfo.gameObject.SetActive(true);
        _resetButton.gameObject.SetActive(true);
        _playerHealthbar.gameObject.SetActive(true);
    }
}
