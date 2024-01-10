using Assets.Scripts.MainMenu;
using Assets.Scripts.PlayerWallet;
using Assets.Scripts.UI.Bar;
using Assets.Scripts.UI.Buttons;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.UI.Screens
{
    public class FightScreen : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private KilledInfo _killedInfo;
        [SerializeField] private RestartButton _resetButton;
        [SerializeField] private PlayerHealthbar _playerHealthbar;
        [SerializeField] private ProgressMap _progressMap;

        public void SetScreen()
        {
            _wallet.gameObject.SetActive(false);
            _killedInfo.gameObject.SetActive(true);
            _progressMap.gameObject.SetActive(false);
            _resetButton.gameObject.SetActive(true);
            _playerHealthbar.gameObject.SetActive(true);
        }
    }
}