using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;

    public override void OnClick()
    {
        _fullVideo.Show();
    }
}