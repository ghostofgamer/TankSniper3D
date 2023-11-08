using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private int _money;

    public event UnityAction MoneyChanged;

    public void AddMoney(int money)
    {
        _money += money;
        MoneyInfo();
    }

    public void DecreaseMoney(int money)
    {
        _money -= money;
        MoneyInfo();
    }

    private void MoneyInfo()
    {
        _moneyText.text = _money.ToString();
    }
}
