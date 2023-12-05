using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ContinueButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;
    [SerializeField] private GameObject _camera;

    private const string MainMenu = "MainScene";

    public override void OnClick()
    {
        //_fullVideo.Show();
        //Destroy(_camera);
        SceneManager.LoadScene(MainMenu);
    }
}
