using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;
    [SerializeField] private TankView _tankView;

    private int _index = 0;

    public override void OnClick()
    {
        _storeScreen.Open();
        _storeScreen.OpenTab(_index);
        _tankView.OffActiveTanks();
    }
}
