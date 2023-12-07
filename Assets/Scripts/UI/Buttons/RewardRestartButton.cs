using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardRestartButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;

    public override void OnClick()
    {
        //_fullVideo.Show();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
