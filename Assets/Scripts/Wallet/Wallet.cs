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

    private int _money;

    public event UnityAction MoneyChanged;

    private void Start()
    {
        _money = _load.GetMoney();
        MoneyInfo();
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyInfo();
        _save.SetMoney(_money);
    }

    public void DecreaseMoney(int money)
    {
        _money -= money;
        MoneyInfo();
        _save.SetMoney(_money);
    }

    private void MoneyInfo()
    {
        _moneyText.text = _money.ToString();
    }
}