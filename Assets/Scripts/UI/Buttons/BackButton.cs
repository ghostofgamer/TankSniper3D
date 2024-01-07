using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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