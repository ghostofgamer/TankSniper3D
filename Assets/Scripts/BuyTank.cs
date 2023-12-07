using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTank : AbstractButton
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _container;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _currenPriceText;
    [SerializeField] private Transform[] _tanks;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private Storage _storage;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _button;

    private List<Transform> _positions;
    private float _offset = 1f;
    private int _startLevel = 1;
    private int _currentLevel;
    private int _currentTankIndex = 1;
    private int _maxLevel = 5;
    private int _price = 5;

    private void Start()
    {
        if (_wallet.Money < _price)
        {
            _button.SetActive(true);
            gameObject.SetActive(false);
            //Image colors = GetComponent<Image>();
            // colors.color = new Color(colors.color.r, colors.color.g, colors.color.b, 0);
            //return;
        }

        _currentLevel = _load.Get(Save.ProgressLevel, _startLevel);
        _price = _currentLevel * 10;
        _positions = new List<Transform>();
        _slider.value = _load.Get(Save.ProgressSlider, 0f);
        _currenPriceText.text = _price.ToString();
        _currentLevelText.text = _currentLevel.ToString();
        //ShowTankPlayer(_currentTankIndex);

        for (int i = 0; i < _position.childCount; i++)
            _positions.Add(_position.GetChild(i));
    }

    public override void OnClick()
    {
        Vector3 position = TryGetPosition();

        if (position == Vector3.zero)
            return;

        if (_wallet.Money >= _price)
        {
            Sell();
        }

        var tank = Instantiate(_tanks[_currentLevel - 1], _container);
        tank.transform.position = new Vector3(position.x, position.y /*+ _offset*/, position.z);
        ChangeValue();
        _storage.AddTank(tank.GetComponent<Tank>());


        if (_wallet.Money < _price)
        {
            _button.SetActive(true);
            //return;
        }
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
            AddPrice();

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

    private void Sell()
    {
        _wallet.DecreaseMoney(_price);
    }

    private void AddPrice()
    {
        Mathf.Clamp(_price = _currentLevel * 10, 0, 60);
        _currenPriceText.text = _price.ToString();
    }
}
