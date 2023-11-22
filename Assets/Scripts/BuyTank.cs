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
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private Storage _storage;

    private List<Transform> _positions;
    private float _offset = 1f;
    private int _startLevel = 1;
    private int _currentLevel;
    private int _currentTankIndex = 1;
    private int _maxLevel = 5;

    private void Start()
    {
        _currentLevel = _load.Get(Save.ProgressLevel, _startLevel);
        _positions = new List<Transform>();
        _slider.value = _load.Get(Save.ProgressSlider,0f);
        _currentLevelText.text = _currentLevel.ToString();
        //ShowTankPlayer(_currentTankIndex);

        for (int i = 0; i < _position.childCount; i++)
            _positions.Add(_position.GetChild(i));
    }

    public void OnClick()
    {
        Vector3 position = TryGetPosition();

        if (position == Vector3.zero)
            return;

        var tank = Instantiate(_tanks[_currentLevel - 1], _container);
        tank.transform.position = new Vector3(position.x, position.y /*+ _offset*/, position.z);
        ChangeValue();
        _storage.AddTank(tank.GetComponent<Tank>());
    }

    private Vector3 TryGetPosition()
    {
        var filter = _positions.FirstOrDefault(p => !p.GetComponent<PositionTank>().IsStay);

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
            {
                _currentLevel = _maxLevel;
                _slider.value = 1;
            }
        }

        _currentLevelText.text = _currentLevel.ToString();
        _currentTankIndex = _currentLevel;
        _save.SetData(Save.ProgressLevel, _currentLevel);
        _save.SetData(Save.ProgressSlider, _slider.value);
    }
}