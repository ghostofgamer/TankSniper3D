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
    [SerializeField] private AudioSource _audioSource;

    private int _startIndex = 0;
    private int _currentIndex = 0;
    private int _currentLevel = 0;

    private void Start()
    {
        ViewTank();
        _currentIndex = _load.Get(Save.Level, _startIndex);
        _currentLevel = _load.Get(Save.CurrentLevel, 0);
    }

    public void ViewTank()
    {
        for (int i = 0; i < _tanks.Length; i++)
        {
            _tanks[i].SetActive(false);
        }

        _tanks[_load.Get(Save.Tank, _startIndex)].SetActive(true);
        //_tanks[_load.Get(Save.Tank, _startIndex)].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
        int index = _load.Get(Save.Tank, _startIndex);
        Material material = _tanks[index].GetComponent<Tank>().GetMaterial();
        _tanks[index].GetComponent<ColoringChanger>().SetMaterial(material);
    }

    public void NewLevelTankView(int level)
    {
        if (_currentLevel < level)
        {
            _effect.Play();
            _audioSource.Play();
            OffActiveTanks();
            _tanks[_load.Get(Save.Tank, _startIndex)].SetActive(true);
            //_tanks[_load.Get(Save.Tank, _startIndex)].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
            Material material = _tanks[_load.Get(Save.Tank, _startIndex)].GetComponentInChildren<Tank>().GetMaterial();
            _tanks[_load.Get(Save.Tank, _startIndex)].GetComponentInChildren<ColoringChanger>().SetMaterial(material);

            if (_currentLevel < level)
            {
                _currentLevel = level;
                _save.SetData(Save.CurrentLevel, _currentLevel);
            }
        }
    }

    public void SetLevelTank(int level)
    {
        if (_currentIndex < level)
            _currentIndex = level;

        _save.SetData(Save.Level, _currentIndex);
    }

    public void OffActiveTanks()
    {
        foreach (var tank in _tanks)
            tank.SetActive(false);
    }
}