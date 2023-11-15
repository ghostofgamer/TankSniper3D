using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;

    private int _startMoney = 0;
    private int _money;

    private void Start()
    {
        _money = _load.Get(Save.Money, _startMoney);
        MoneyInfo();
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyInfo();
        _save.SetData(Save.Money, _money);
    }

    public void DecreaseMoney(int money)
    {
        _money -= money;
        MoneyInfo();
        _save.SetData(Save.Money, _money);
    }

    private void MoneyInfo()
    {
        _moneyText.text = _money.ToString();
    }
}