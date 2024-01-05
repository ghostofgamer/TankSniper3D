using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankChanger : AbstractButton
{
    [SerializeField] private List<GameObject> _tanks;
    //[SerializeField] private List<TMP_Text> _tanksName;
    //[SerializeField] private TMP_Text _tankLevel;
    [SerializeField] private int _index;
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;
    [SerializeField] private MaterialContainer _materialContainer;
    [SerializeField] private TankConfig _tankConfig;
    [SerializeField] private StoreScreen _storeScreen;

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
        //_tanks[_currentIndex].GetComponentInChildren<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
        Material material = _tanks[_currentIndex].GetComponentInChildren<Tank>().GetMaterial();
        _tanks[_currentIndex].GetComponentInChildren<ColoringChanger>().SetMaterial(material);
        _save.SetData(Save.Tank, _currentIndex);
        //_storeScreen.GetInfo(_tanks[_currentIndex].GetComponentInChildren<Tank>().Name, _tanks[_currentIndex].GetComponentInChildren<Tank>().Level);
    }

    private void OffTanks()
    {
        foreach (GameObject tank in _tanks)
            tank.SetActive(false);
    }
}