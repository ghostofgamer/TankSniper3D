#if UNITY_WEBGL && YANDEX_PLATFORM
using Agava.WebUtility;
#endif
using Assets.Scripts.GamePlayer.Aim;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScreenFocus : MonoBehaviour
    {
        private AimInputButton _aimInputButton;
        private int _stop = 0;
        private int _play = 1;

        private void OnEnable()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
#if UNITY_WEBGL && YANDEX_PLATFORM
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
#endif
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnInBackgroundChangeApp;
#if UNITY_WEBGL && YANDEX_PLATFORM
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
#endif
        }

        public void Init(AimInputButton aimInputButton)
        {
            _aimInputButton = aimInputButton;
        }

        private void OnInBackgroundChangeApp(bool inApp)
        {
            SetValueAudio(!inApp);
            PauseGame(!inApp);
        }

        private void OnInBackgroundChangeWeb(bool isBackground)
        {
            if (isBackground)
                _aimInputButton.ReturnHide();

            SetValueAudio(isBackground);
            PauseGame(isBackground);
        }

        private void SetValueAudio(bool value)
        {
            AudioListener.pause = value;
        }

        private void PauseGame(bool value)
        {
            Time.timeScale = value ? _stop : _play;
        }
    }
}