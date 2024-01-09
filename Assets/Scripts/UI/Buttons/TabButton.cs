using UnityEngine;

namespace Tank3D
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