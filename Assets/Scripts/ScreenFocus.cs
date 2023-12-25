using Agava.WebUtility;
using System.Collections;
using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    [SerializeField] private Load _load;

    private AimInputButton _aimInputButton;

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
        if (_load.Get(Save.Ad, 0) == 1)
        {
            return;
        }

        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        if (isBackground)
            _aimInputButton.ReturnHide();

        if (_load.Get(Save.Ad, 0) == 1)
        {
            return;
        }

        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.pause = value ? true : false;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}