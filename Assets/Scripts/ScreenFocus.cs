using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    [SerializeField] private SettingsScreen _settingsScreen;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        if (_settingsScreen.GetComponent<CanvasGroup>().alpha == 0)
        {
            MuteAudio(!inApp);
            PauseGame(!inApp);
        }
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        if (_settingsScreen.GetComponent<CanvasGroup>().alpha == 0)
        {
            MuteAudio(isBackground);
            PauseGame(isBackground);

        }
    }

    private void MuteAudio(bool value)
    {
        //AudioListener.volume= value ? 0 : 1;
        AudioListener.pause = value ? true : false;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}