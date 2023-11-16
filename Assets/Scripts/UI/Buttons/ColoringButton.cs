using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringButton : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;
    [SerializeField] private Material _material;

    public override void OnClick()
    {
        var tank =  _storeScreen.GetTank();
        tank.GetComponent<ColoringChanger>().SetMaterial(_material);
    }
}
