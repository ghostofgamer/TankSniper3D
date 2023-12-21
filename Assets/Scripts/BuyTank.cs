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
    [SerializeField] private Transform[] _positionsIndex;
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
    private bool _isWaveEnd = false;
    private int _levelBuy;

    public int Price { get; private set; } = 5;

    private void Start()
    {
        if (_wallet.Money < Price)
        {
            _button.SetActive(true);
            gameObject.SetActive(false);
            //Image colors = GetComponent<Image>();
            // colors.color = new Color(colors.color.r, colors.color.g, colors.color.b, 0);
            //return;
        }

        _currentLevel = _load.Get(Save.ProgressLevel, _startLevel);
        _levelBuy = _load.Get(Save.LevelBuy, _startLevel);
        Price = _levelBuy * 3000;
        _positions = new List<Transform>();
        _slider.value = _load.Get(Save.ProgressSlider, 0f);
        _currenPriceText.text = Price.ToString();
        _currentLevelText.text = _levelBuy.ToString();
        //Debug.Log("В старте " + _levelBuy);
        //_currentLevelText.text = _currentLevel.ToString();
        //ShowTankPlayer(_currentTankIndex);

        //for (int i = 0; i < _position.childCount; i++)
        //    _positions.Add(_position.GetChild(i));

        int index = _load.Get(Save.Enviropment, 0);

        for (int i = 0; i < _positionsIndex[index].childCount; i++)
            _positions.Add(_positionsIndex[index].GetChild(i));

        _storage.Init(_positions);
    }

    //public void GetList(Transform transforms)
    //{
    //    for (int i = 0; i < transforms.childCount; i++)
    //        _positions.Add(transforms.GetChild(i));
    //}

    public void Init(List<Transform> positions)
    {
        _positions = positions;
    }

    public override void OnClick()
    {
        //Vector3 position = TryGetPosition();
        Transform position = TryGetPosition();

        if (position == null)
            return;

        if (_wallet.Money >= Price)
        {
            Sell();
        }

        //_tanks[_currentLevel - 1].GetComponent<DragItem>().SetLevel(_load.Get(_tanks[_currentLevel - 1].GetComponent<DragItem>().TankName, _tanks[_currentLevel - 1].GetComponent<DragItem>().Level));
        //Debug.Log("Ломается " + (_currentLevel - 1));
        int needNumber = _load.Get(_tanks[_currentLevel - 1].GetComponent<DragItem>().TankName, _tanks[_currentLevel - 1].GetComponent<DragItem>().Level);
        //Debug.Log("Загружается " + needNumber);

        var tank = Instantiate(_tanks[_currentLevel - 1], _container);
        tank.GetComponent<DragItem>().SetLevel(needNumber /*- 1*/);

        //tank.GetComponent<DragItem>().SetLevel(_load.Get(tank.GetComponent<DragItem>().TankName, tank.GetComponent<DragItem>().Level));
        //Debug.Log("ЧТО " + _load.Get(tank.GetComponent<DragItem>().TankName, tank.GetComponent<DragItem>().Level + 1));


        tank.transform.position = position.position;
        //new Vector3(position.x, position.y /*+ _offset*/, position.z);
        //tank.transform.rotation = position.rotation;
        _storage.AddTank(tank.GetComponent<Tank>());


        if (_wallet.Money < Price)
        {
            _button.SetActive(true);
            //return;
        }

        ChangeValue();
    }

    public void GetTank()
    {
        Transform position = TryGetPosition();
        _tanks[_currentLevel - 1].GetComponent<DragItem>().SetLevel(_load.Get(_tanks[_currentLevel - 1].GetComponent<DragItem>().TankName, _tanks[_currentLevel - 1].GetComponent<DragItem>().Level + 1));
        var tank = Instantiate(_tanks[_currentLevel - 1], _container);
        //tank.GetComponent<DragItem>().SetLevel(_load.Get(tank.GetComponent<DragItem>().TankName, tank.GetComponent<DragItem>().Level + 1));
        tank.transform.position = position.position;
        //new Vector3(position.x, position.y /*+ _offset*/, position.z);
        //tank.transform.rotation = position.rotation;
        _storage.AddTank(tank.GetComponent<Tank>());
    }

    private Transform TryGetPosition()
    {
        var filter = _positions.FirstOrDefault(p => !p.GetComponent<PositionTank>().IsStay);

        if (filter == null)
            return null;

        return filter.transform;
        //return filter.position;
    }

    private int GetMinLevel()
    {
        List<int> indexes = new List<int>();

        foreach (var position in _positions)
        {
            if (position.GetComponent<PositionTank>().Target)
            {
                //int index = position.GetComponent<PositionTank>().Target.GetComponent<Tank>().Level;
                int index = position.GetComponent<PositionTank>().Target.GetComponent<DragItem>().LevelMerge;
                indexes.Add(index);
            }
        }

        if (indexes.Count > 0)
            return indexes.Min();

        else
            return 0;
        //_positions
    }

    private int GetMaxLevel()
    {
        List<int> indexes = new List<int>();

        foreach (var position in _positions)
        {
            if (position.GetComponent<PositionTank>().Target)
            {
                //int index = position.GetComponent<PositionTank>().Target.GetComponent<Tank>().Level;
                int index = position.GetComponent<PositionTank>().Target.GetComponent<DragItem>().LevelMerge;
                indexes.Add(index);
            }
        }

        if (indexes.Count > 0)
            return indexes.Max();

        else
            return 0;
        //_positions
    }

    private int GetMinIndex()
    {
        List<int> indexes = new List<int>();

        foreach (var position in _positions)
        {
            if (position.GetComponent<PositionTank>().Target)
            {
                int index = position.GetComponent<PositionTank>().Target.GetComponent<Tank>().Level;
                //int index = position.GetComponent<PositionTank>().Target.GetComponent<DragItem>().LevelMerge;
                indexes.Add(index);
            }
        }

        if (indexes.Count > 0)
            return indexes.Min();

        else
            return 0;
        //_positions
    }

    private int GetMaxIndex()
    {
        List<int> indexes = new List<int>();

        foreach (var position in _positions)
        {
            if (position.GetComponent<PositionTank>().Target)
            {
                int index = position.GetComponent<PositionTank>().Target.GetComponent<Tank>().Level;
                //int index = position.GetComponent<PositionTank>().Target.GetComponent<DragItem>().LevelMerge;
                indexes.Add(index);
            }
        }

        if (indexes.Count > 0)
            return indexes.Max();

        else
            return 0;
        //_positions
    }

    private void ChangeValue()
    {
        int index = GetMinLevel() + 1;

        if (/*index == _levelBuy &&*/ _slider.value < 1)
            _slider.value += 0.25f;


        //if (index == _currentLevel || _slider.value != 1)
        //    _slider.value += 0.3f;

        StartCoroutine(OnSetValue());
        //if (_slider.value == 1 && index > _currentLevel)
        //{
        //    _slider.value = 0;
        //    _currentLevel++;
        //    AddPrice();

        //    if (_currentLevel >= _maxLevel)
        //    {
        //        _currentLevel = _maxLevel;
        //        _slider.value = 1;
        //    }
        //}

        //_currentLevelText.text = _currentLevel.ToString();
        //_currentTankIndex = _currentLevel;
        //_save.SetData(Save.ProgressLevel, _currentLevel);
        //_save.SetData(Save.ProgressSlider, _slider.value);
    }

    public void SetValue()
    {
        int minLevelMerge = GetMinLevel() + 1;
        //Debug.Log("индекс" + index);
        int minIndex = GetMinIndex() + 1;
        int maxIndex = GetMaxIndex() + 1;
        //Debug.Log("MSX " + max);

        if (maxIndex > _maxLevel)
        {
            //_isWaveEnd = true;
            int _allOpen = 1;
            _save.SetData(Save.AllTanksOpen, _allOpen);
        }

        if (_isWaveEnd)
        {
            if (_slider.value == 1 && _maxLevel > maxIndex /*|| min == _startLevel && _slider.value == 1*/)
            {
                //Debug.Log("Внутри");
                _currentLevel = _startLevel;
                _slider.value = 0;
                _levelBuy++;
                AddPrice();
                _isWaveEnd = false;
                _save.SetData(Save.LevelBuy, _levelBuy);
            }

            //if (_slider.value == 1 && max == _startLevel || min == _startLevel && _slider.value == 1)
            //{
            //    _currentLevel = _startLevel;
            //    _slider.value = 0;
            //    _levelBuy++;
            //    AddPrice();
            //    _isWaveEnd = false;
            //    _save.SetData(Save.LevelBuy, _levelBuy);
            //}
        }


        //if (_slider.value == 1 && index > _currentLevel)

        if (_slider.value == 1 /*&& minLevelMerge - 1 > _levelBuy*/)
        {
            if (minLevelMerge - 1 > _levelBuy)
            {
                _slider.value = 0;
                _levelBuy++;
                _currentLevel++;


                //if (_currentLevel > _maxLevel)
                    if (_currentLevel > 6)
                    _currentLevel = _startLevel;

                AddPrice();
            }

            //if()
            //_slider.value = 0;
            //_currentLevel++;
            //_levelBuy++;
            //AddPrice();
        }

        //_currentLevelText.text = _currentLevel.ToString();
        //Debug.Log("При след уровне " + _levelBuy);
        //_levelBuy++;
        _currentLevelText.text = _levelBuy.ToString();
        _currentTankIndex = _currentLevel;
        _save.SetData(Save.ProgressLevel, _currentLevel);
        _save.SetData(Save.ProgressSlider, _slider.value);
        _save.SetData(Save.LevelBuy, _levelBuy);
    }

    //public void SetValue()
    //{
    //    int index = CheckPositionsLevel() + 1;
    //    //Debug.Log("индекс" + index);
    //    int min = GetMinPositionsLevel() + 1;
    //    int max = GetMaxLevel() + 1;
    //    //Debug.Log("MSX " + max);

    //    if (max > _maxLevel)
    //    {
    //        _isWaveEnd = true;
    //        int _allOpen = 1;
    //        _save.SetData(Save.AllTanksOpen, _allOpen);
    //    }

    //    if (_isWaveEnd)
    //    {

    //        //Debug.Log("максимум " + max);
    //        //Debug.Log("минимум " + min);
    //        //Debug.Log("cnfhn " + _startLevel);


    //        if (_slider.value == 1 && _maxLevel > max /*|| min == _startLevel && _slider.value == 1*/)
    //        {
    //            //Debug.Log("Внутри");
    //            _currentLevel = _startLevel;
    //            _slider.value = 0;
    //            _levelBuy++;
    //            AddPrice();
    //            _isWaveEnd = false;
    //            _save.SetData(Save.LevelBuy, _levelBuy);
    //        }
    //        //if (_slider.value == 1 && max == _startLevel || min == _startLevel && _slider.value == 1)
    //        //{
    //        //    _currentLevel = _startLevel;
    //        //    _slider.value = 0;
    //        //    _levelBuy++;
    //        //    AddPrice();
    //        //    _isWaveEnd = false;
    //        //    _save.SetData(Save.LevelBuy, _levelBuy);
    //        //}
    //    }


    //    //if (_slider.value == 1 && index > _currentLevel)
    //    //Debug.Log("Индекс " + index);
    //    //Debug.Log("LevelBuy " + _levelBuy);

    //    if (_slider.value == 1 && index - 1 > _levelBuy)
    //    {
    //        //Debug.Log("ААА");
    //        _slider.value = 0;
    //        _currentLevel++;
    //        _levelBuy++;
    //        AddPrice();

    //        if (_currentLevel > _maxLevel)
    //        {
    //            //_currentLevel = _startLevel;
    //            //_slider.value = 0;
    //            //_currentLevel = _maxLevel;
    //            //_slider.value = 1;
    //        }
    //    }

    //    //_currentLevelText.text = _currentLevel.ToString();
    //    //Debug.Log("При след уровне " + _levelBuy);
    //    //_levelBuy++;
    //    _currentLevelText.text = _levelBuy.ToString();
    //    _currentTankIndex = _currentLevel;
    //    _save.SetData(Save.ProgressLevel, _currentLevel);
    //    _save.SetData(Save.ProgressSlider, _slider.value);
    //    _save.SetData(Save.LevelBuy, _levelBuy);
    //}

    private void Sell()
    {
        _wallet.DecreaseMoney(Price);
    }

    private void AddPrice()
    {
        Price = _levelBuy * 3000;
        _currenPriceText.text = Price.ToString();
    }

    private IEnumerator OnSetValue()
    {
        yield return new WaitForSeconds(0.15f);
        SetValue();
    }
}