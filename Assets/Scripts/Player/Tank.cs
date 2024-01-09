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
    [SerializeField] private Material[] _materials;
    [SerializeField] private TanksColor _colorTank;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;

    private int _defaultIndexColor = 9;

    public int Level => _level;

    public string Name => _name;

    public void SetMaterial(int index)
    {
        _save.SetData(_colorTank.ToString(), index);
    }

    public Material GetMaterial()
    {
        int index = _load.Get(_colorTank.ToString(), _defaultIndexColor);
        return _materials[index];
    }
}