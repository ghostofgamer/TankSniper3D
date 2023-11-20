using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTank : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _container;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private Transform[] _tanks;
    [SerializeField] private SaveSystem _saveSystem;

    private List<Transform> _positions;
    private float _offset = 1f;
    private int _currentLevel = 1;
    private int _currentTankIndex = 1;
    private int _maxLevel = 3;

    private void Start()
    {
        _positions = new List<Transform>();
        _slider.value = 0;
        //ShowTankPlayer(_currentTankIndex);

        for (int i = 0; i < _position.childCount; i++)
            _positions.Add(_position.GetChild(i));
    }

    public void OnClick()
    {
        Vector3 position = TryGetPosition();

        if (position == Vector3.zero)
            return;

        var tank = Instantiate(_tanks[_currentTankIndex - 1], _container);
        tank.transform.position = new Vector3(position.x, position.y /*+ _offset*/, position.z);
        ChangeValue();
        //_saveSystem.AddTank(tank.gameObject);
        //_saveSystem.Filter();
    }

    private Vector3 TryGetPosition()
    {
        var filter = _positions.FirstOrDefault(p => !p.GetComponent<Cub>().IsStay);

        if (filter == null)
            return Vector3.zero;

        return filter.position;
    }

    private void ChangeValue()
    {
        _slider.value += 0.3f;

        if (_slider.value == 1)
        {
            _slider.value = 0;
            _currentLevel++;

            if (_currentLevel >= _maxLevel)
                _currentLevel = _maxLevel;
        }

        _currentLevelText.text = _currentLevel.ToString();
        _currentTankIndex = _currentLevel;
        //ShowTankPlayer(_currentTankIndex);
    }

    //private void ShowTankPlayer(int index)
    //{
    //    for (int i = 0; i < _tanks.Length; i++)
    //    {
    //        if (i == index - 1)
    //            _tanks[i].gameObject.SetActive(true);
    //        else
    //            _tanks[i].gameObject.SetActive(false);
    //    }
    //}
}
