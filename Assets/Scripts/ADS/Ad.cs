using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Ad : MonoBehaviour
{
    private int _volumeValue;

    public abstract void Show();

    public void SetVolume(int volume)
    {
        _volumeValue = volume;
    }

    protected virtual void OnOpen()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }

    protected virtual void OnClose(bool isClosed)
    {
        Time.timeScale = 1;
        AudioListener.volume = _volumeValue;
        SceneManager.LoadScene("MainScene");
    }

    protected virtual void OnClose()
    {
        Time.timeScale = 1;
        AudioListener.volume = _volumeValue;
    }
}