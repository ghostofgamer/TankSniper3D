using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullAds : Ad
{
    public override void Show()
    {
        if (YandexGamesSdk.IsInitialized)
            InterstitialAd.Show(OnOpen, OnClose);
    }
}