using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SdkInitialization : MonoBehaviour
    {
        private const string MainScene = "MainScene";

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            YandexGamesSdk.GameReady();
            SceneManager.LoadScene(MainScene);
        }
    }
}