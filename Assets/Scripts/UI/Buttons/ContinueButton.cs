using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ContinueButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;

    private const string MainMenu = "MainScene";

    public override void OnClick()
    {
        //_fullVideo.Show();
        SceneManager.LoadScene(MainMenu);
    }
}
