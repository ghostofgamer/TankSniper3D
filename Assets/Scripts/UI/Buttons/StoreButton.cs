using Assets.Scripts.MainMenu;
using Assets.Scripts.MergeTanks;
using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class StoreButton : AbstractButton
    {
        [SerializeField] private StoreScreen _storeScreen;
        [SerializeField] private TankView _tankView;
        [SerializeField] private Merge _merge;

        private int _index = 0;

        public override void OnClick()
        {
            _storeScreen.Open();
            _storeScreen.OpenTab(_index);
            _tankView.DisableActiveTanks();
            _merge.enabled = false;
            Time.timeScale = 1;
        }
    }
}