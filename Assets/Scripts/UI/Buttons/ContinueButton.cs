using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tank3D
{
    public class ContinueButton : AbstractButton
    {
        private const string MainMenu = "MainScene";

        [SerializeField] private FullAds _fullVideo;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private EndGame _endGameScreen;
        [SerializeField] private GameObject _moneyFly;
        [SerializeField] private GameObject _moneyFlyMobile;
        [SerializeField] private RouletteContinueButton _rouletteContinueButton;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

        public override void OnClick()
        {
            _rouletteContinueButton.SetActive();
            StartCoroutine(GetMoney());
        }

        private IEnumerator GetMoney()
        {
            if (Application.isMobilePlatform)
                _moneyFlyMobile.SetActive(true);
            else
                _moneyFly.SetActive(true);

            _wallet.AddMoney(_endGameScreen.ViewReward);
            yield return _waitForSeconds;
            SceneManager.LoadScene(MainMenu);
        }
    }
}