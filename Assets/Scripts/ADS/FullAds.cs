using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class FullAds : Ad
{
    public override void Show()
    {
        if (YandexGamesSdk.IsInitialized)
            InterstitialAd.Show(OnOpen, OnClose);
    }

    //protected override void OnClose(bool isClosed)
    //{
    //    base.OnClose(isClosed);
    //    SceneManager.LoadScene("MainScene");
    //}
}