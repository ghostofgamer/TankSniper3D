using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSkin : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;

    private int _defaultIndex = 9;

    public override void OnClick()
    {
        var tank =  _storeScreen.GetTank();
        Material material = tank.GetComponentInChildren<Tank>().DefaultMaterial;
        tank.GetComponentInChildren<ColoringChanger>().SetMaterial(material);
        tank.GetComponentInChildren<Tank>().SetMaterial(/*material, */_defaultIndex);
    }
}