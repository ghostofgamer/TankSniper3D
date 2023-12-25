using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Ad : MonoBehaviour
{
    [SerializeField] private Load _load;
    int _volume;
    int _startSound = 1;

    public abstract void Show();

    protected virtual void OnOpen()
    {
        Time.timeScale = 0;

        _volume = _load.Get(Save.Sound, _startSound);

        if (_volume != 0)
            AudioListener.volume = 0;
        //AudioListener.pause = true;
    }

    protected virtual void OnClose(bool isClosed)
    {
        Time.timeScale = 1;
        //AudioListener.pause = false;
        _volume = _load.Get(Save.Sound, _startSound);

        if (_volume == 1)
            AudioListener.volume = 1;

        SceneManager.LoadScene("MainScene");
    }

    protected virtual void OnClose()
    {
        Time.timeScale = 1;
        //AudioListener.pause = false;
        _volume = _load.Get(Save.Sound, _startSound);

        if (_volume == 1)
            AudioListener.volume = 1;
    }
}