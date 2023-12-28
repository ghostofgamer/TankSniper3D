using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;
    private const string MainScene = "MainScene";
    public override void OnClick()
    {
        SceneManager.LoadScene(MainScene);
        //_fullVideo.Show();
    }
}