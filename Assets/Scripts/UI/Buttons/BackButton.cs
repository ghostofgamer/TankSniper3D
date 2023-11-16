using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;

    public override void OnClick()
    {
        _storeScreen.Close();
        _storeScreen.SetItem();
    }
}
