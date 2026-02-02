using Agava.YandexGames;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameReady : MonoBehaviour
    {
        private void Start()
        {
#if YANDEX_PLATFORM
            YandexGamesSdk.GameReady();
#endif
        }
    }
}