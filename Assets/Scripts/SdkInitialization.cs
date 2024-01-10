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
            yield return YandexGamesSdk.Initialize(EnableInitialized);
        }

        private void EnableInitialized()
        {
            YandexGamesSdk.GameReady();
            SceneManager.LoadScene(MainScene);
        }
    }
}