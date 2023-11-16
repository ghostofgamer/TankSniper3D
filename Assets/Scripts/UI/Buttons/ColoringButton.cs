using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringButton : AbstractButton
{
    [SerializeField] private StoreScreen _storeScreen;
    [SerializeField] private Material _material;

    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private int _index;
    [SerializeField] private int _startIndex = 0;
    [SerializeField] private Material[] _materials;

    private GameObject[] _tanks;

    private void Start()
    {
        //int number = _load.Get(Save.Color, _startIndex);

        //int count = _storeScreen.Items.Length;
        //_tanks = _storeScreen.Items;

        //for (int i = 0; i < count; i++)
        //{
        //    _tanks[i].GetComponent<ColoringChanger>().SetMaterial(_materials[1]);
        //}

        //for (int i = 0; i < _materials.Length; i++)
        //{
        //    if (number == i)
        //    {
        //        for (int j = 0; j < _storeScreen.Items.Length; j++)
        //        {
        //            _storeScreen.Items[i].GetComponent<ColoringChanger>().SetMaterial(_material);
        //        }
        //    }
        //}

    }

    public override void OnClick()
    {
        //int count = _storeScreen.Items.Length;
        //Debug.Log(count);
        //_tanks = _storeScreen.Items;

        //for (int i = 0; i < count; i++)
        //{
        //    _tanks[i].GetComponent<ColoringChanger>().SetMaterial(_material);
        //    Debug.Log(i);
        //}


        var tank = _storeScreen.GetTank();
        tank.GetComponent<ColoringChanger>().SetMaterial(_material);
        _save.SetData(Save.Color, _index);
    }
}
