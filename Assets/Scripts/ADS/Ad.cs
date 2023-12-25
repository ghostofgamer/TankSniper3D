using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Ad : MonoBehaviour
{
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;

    int _volume  = 0;
    int _startSound = 1;

    public abstract void Show();

    protected virtual void OnOpen()
    {
        _save.SetData(Save.Ad, 1);
        //_volume = _load.Get(Save.Sound, _startSound);
        Time.timeScale = 0;
        //AudioListener.volume = 0;
        AudioListener.pause = true;
    }

    protected virtual void OnClose(bool isClosed)
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        //_volume = _load.Get(Save.Sound, _startSound);

        //if (_volume == 1)
        //AudioListener.volume = _volume;
        _save.SetData(Save.Ad, 0);
        SceneManager.LoadScene("MainScene");
    }

    protected virtual void OnClose()
    {
        //_volume = _load.Get(Save.Sound, _startSound);
        Time.timeScale = 1;
        AudioListener.pause = false;
        _save.SetData(Save.Ad, 0);
        //_volume = _load.Get(Save.Sound, 0);

        //if (_volume == 1)
        //AudioListener.volume = _volume;
    }
}