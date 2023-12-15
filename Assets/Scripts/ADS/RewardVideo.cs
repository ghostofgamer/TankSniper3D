using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class RewardVideo : Ad
{
    //[SerializeField] private BuyButton buyButton;

    public override void Show()
    {
        if (YandexGamesSdk.IsInitialized)
            VideoAd.Show(OnOpen, OnReward, OnClose);
    }

    public virtual void OnReward()
    {
        //buyButton.OffActive();
    }
}