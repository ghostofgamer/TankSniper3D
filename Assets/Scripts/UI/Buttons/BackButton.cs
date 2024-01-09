using Assets.Scripts.MainMenu;
using Assets.Scripts.MergeTanks;
using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class BackButton : AbstractButton
    {
        [SerializeField] private StoreScreen _storeScreen;
        [SerializeField] private TankView _tankView;
        [SerializeField] private Merge _merge;

        public override void OnClick()
        {
            _storeScreen.Close();
            _storeScreen.SetItem();
            _tankView.Show();
            _merge.enabled = true;
        }
    }
}