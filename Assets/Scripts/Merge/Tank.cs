using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TanksColor
{
    SimpleColor,
    CannonColor,
    RocketColor,
    FireballColor,
    MissileColor,
    LazerColor
}

public class Tank : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private string _name;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material[] _materials;
    [SerializeField] private TanksColor _colorTank;
    //[SerializeField] private int _materialIndex;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;

    public int Level => _level;
    public string Name => _name;
    public Material DefaultMaterial => _defaultMaterial;

    private int _defaultIndexColor = 9;
    private string _colorTankName;

    private void OnEnable()
    {
        //Debug.Log("Мой индекс " + _load.Get(_colorTankName, _defaultIndexColor));
    }

    private void Start()
    {
        _colorTankName = _colorTank.ToString();
        Debug.Log("Имя " + _colorTankName);
    }

    public void SetMaterial(int index)
    {
        //Debug.Log("Мой индекс сохранение " + index);
        //_save.SetData(_colorTankName, index);
        _save.SetData(_colorTank.ToString(), index);
        //_save.SetData(Save.SimpleColor, index);
    }

    public Material GetMaterial()
    {
        //_load.Get(_colorTankName, _defaultIndexColor);
        //Debug.Log("Мой индекс загрузка " + _load.Get(_colorTankName, _defaultIndexColor));
        int index = _load.Get(_colorTank.ToString(), _defaultIndexColor);
        //int index = _load.Get(Save.SimpleColor, _defaultIndexColor);
        return _materials[index];
    }
}