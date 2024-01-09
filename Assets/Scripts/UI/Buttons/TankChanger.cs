using System.Collections.Generic;
using UnityEngine;

public class TankChanger : AbstractButton
{
    [SerializeField] private List<GameObject> _tanks;
    [SerializeField] private int _index;
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;

    private int _currentIndex;
    private int _startIndex = 0;

    private void Start()
    {
        _currentIndex = _load.Get(Save.Tank, _startIndex);
    }

    public override void OnClick()
    {
        SetTank();
    }

    private void SetTank()
    {
        OffTanks();
        _currentIndex = _index;
        _tanks[_currentIndex].SetActive(true);
        Material material = _tanks[_currentIndex].GetComponentInChildren<Tank>().GetMaterial();
        _tanks[_currentIndex].GetComponentInChildren<ColoringChanger>().SetMaterial(material);
        _save.SetData(Save.Tank, _currentIndex);
    }

    private void OffTanks()
    {
        foreach (GameObject tank in _tanks)
            tank.SetActive(false);
    }
}