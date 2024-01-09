using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Ad : MonoBehaviour
{
    private const string MainScene = "MainScene";

    private int _volumeValue;

    public abstract void Show();

    public void SetVolume(int volume)
    {
        _volumeValue = volume;
    }

    protected virtual void OnOpen()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    protected virtual void OnClose(bool isClosed)
    {
        Time.timeScale = 1;
        AudioListener.volume = _volumeValue;
        SceneManager.LoadScene(MainScene);
    }

    protected virtual void OnClose()
    {
        Time.timeScale = 1;
        AudioListener.volume = _volumeValue;
    }
}