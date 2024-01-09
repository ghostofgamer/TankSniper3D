using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class TabButton : AbstractButton
    {
        [SerializeField] private StoreScreen _storeScreen;
        [SerializeField] private int _index;

        public override void OnClick()
        {
            _storeScreen.OpenTab(_index);
        }
    }
}