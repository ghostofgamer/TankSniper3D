using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;
    [SerializeField] private int _index;

    public override void OnClick()
    {
        _storeScreen.OpenTab(_index);
    }
}