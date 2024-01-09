using System.Collections;
using Agava.WebUtility;
using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    private AimInputButton _aimInputButton;

    private int _stop = 0;
    private int _play = 1;

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

    public void Init(AimInputButton aimInputButton)
    {
        _aimInputButton = aimInputButton;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        if (isBackground)
            _aimInputButton.ReturnHide();

        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.pause = value ? true : false;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? _stop : _play;
    }
}