using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Ad : MonoBehaviour
{
    private bool _isActive;

    public abstract void Show();

    protected virtual void OnOpen()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
        //AudioListener.pause = true;
    }

    protected virtual void OnClose(bool isClosed)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
        //AudioListener.pause = false;
        SceneManager.LoadScene("MainScene");
    }

    //protected virtual void OnCloseContinue(bool isClosed)
    //{
    //    Time.timeScale = 1;
    //    AudioListener.volume = 1f;
    //    AudioListener.pause = false;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    protected void OnClose()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}