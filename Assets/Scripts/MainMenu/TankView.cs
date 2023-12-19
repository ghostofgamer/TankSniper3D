using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Load _load;
    [SerializeField] private GameObject[] _tanks;
    [SerializeField] private MaterialContainer _materialContainer;
    [SerializeField] private Save _save;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioPlugin _audioPlugin;

    private int _startIndex = 0;
    private int _currentLevel = 0;

    private void Start()
    {
        ViewTank();
        _currentLevel = _load.Get(Save.Level, _startIndex);
    }

    public void ViewTank()
    {
        for (int i = 0; i < _tanks.Length; i++)
        {
            _tanks[i].SetActive(false);
        }

            _tanks[_load.Get(Save.Tank, _startIndex)].SetActive(true);
            _tanks[_load.Get(Save.Tank, _startIndex)].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
    }

    public void NewLevelTankView()
    {
        _effect.Play();
        _audioPlugin.PlayKey();
        OffActiveTanks();
        _tanks[_load.Get(Save.Tank, _startIndex)].SetActive(true);
        _tanks[_load.Get(Save.Tank, _startIndex)].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
    }

    public void SetLevelTank(int level)
    {
        if (_currentLevel < level)
            _currentLevel = level;

        _save.SetData(Save.Level, _currentLevel);
    }

    public void OffActiveTanks()
    {
        foreach (var tank in _tanks)
            tank.SetActive(false);
    }
}