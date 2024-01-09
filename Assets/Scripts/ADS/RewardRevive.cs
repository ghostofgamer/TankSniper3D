using Assets.Scripts.GameCamera;
using Assets.Scripts.GamePlayer;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ADS
{
    public class RewardRevive : RewardVideo
    {
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private PanelInfo _panelInfo;
        [SerializeField] private CameraMovement _reviewCamera;

        public override void OnReward()
        {
            _gameOverScreen.Close();
            _panelInfo.Open();
            _reviewCamera.enabled = true;
            _gameOverScreen.Player.GetComponent<PlayerFire>().StewFire();
            _gameOverScreen.Player.Revive();
        }

        protected override void OnClose()
        {
            base.OnClose();
            GetComponent<Button>().interactable = true;
        }
    }
}