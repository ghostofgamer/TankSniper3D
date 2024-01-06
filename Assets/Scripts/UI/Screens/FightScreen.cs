using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScreen : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private ResetButton _resetButton;
    [SerializeField] private PlayerHealthbar _playerHealthbar;
    [SerializeField]private ProgressMap _progressMap;

    private Weapon _weapon;

    public void Init(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnSetScreen()
    {
        _wallet.gameObject.SetActive(false);
        _killedInfo.gameObject.SetActive(true);
        _progressMap.gameObject.SetActive(false);
        _resetButton.gameObject.SetActive(true);
        _playerHealthbar.gameObject.SetActive(true);
    }
}