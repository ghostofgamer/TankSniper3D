using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardTank : RewardVideo
{
    [SerializeField] private BuyTank _button;
    [SerializeField] private Wallet _wallet;

    //private void Start()
    //{
    //    if (_wallet.Money > _button.Price)
    //    {
    //        _button.gameObject.SetActive(true);
    //        gameObject.SetActive(false);
    //    }
    //}

    public override void OnReward()
    {
        //_button.GetTank();
        _button.OnClick();
    }
}
