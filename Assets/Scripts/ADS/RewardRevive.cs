using UnityEngine;
using UnityEngine.UI;

namespace Tank3D
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