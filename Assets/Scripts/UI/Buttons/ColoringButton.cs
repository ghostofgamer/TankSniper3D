using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringButton : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private MaterialContainer _materialContainer;
    [SerializeField] private int _index;

    public override void OnClick()
    {
        var tank = _storeScreen.GetTank();
        _save.SetData(Save.Color, _index);
        tank.GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
    }
}