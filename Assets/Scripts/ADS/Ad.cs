using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Ad : MonoBehaviour
{
    public abstract void Show();

    protected virtual void OnOpen()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    protected virtual void OnClose(bool isClosed)
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainScene");
    }

    protected void OnClose()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}