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
        //Debug.Log("Current " + _currentLevel);
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

    public void NewLevelTankView(int level/*GameObject objectMerge*/)
    {
        //Debug.Log("LVL " + _currentIndex);
        //Debug.Log("IND " + level);

        if (_currentLevel < level)
        {

            Debug.Log("Current " + _currentLevel);
            //Debug.Log("LEVELS " + level);

            _effect.Play();
            //_audioPlugin.PlayKey();
            _audioSource.Play();
            OffActiveTanks();
            _tanks[_load.Get(Save.Tank, _startIndex)].SetActive(true);
            _tanks[_load.Get(Save.Tank, _startIndex)].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());

            if (_currentLevel < level)
            {
                _currentLevel = level;
                _save.SetData(Save.CurrentLevel, _currentLevel);
            }
        }
        //_currentIndex = _load.Get(Save.LevelBuy, 1);
        ////Debug.Log("Level " + _currentIndex);
        ////Debug.Log("покупка " + _load.Get(Save.LevelBuy, 1));
        //if (_currentIndex == _load.Get(Save.LevelBuy, 1))
        //{
        //_currentIndex = _load.Get(Save.LevelBuy, 1);
        //}
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