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
        //tank.GetComponentInChildren<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
        tank.GetComponent<Tank>().SetMaterial(_index);
        tank.GetComponentInChildren<Animator>().Play(0);
        Material material = tank.GetComponent<Tank>().GetMaterial();
        tank.GetComponentInChildren<ColoringChanger>().SetMaterial(material);
    }
}