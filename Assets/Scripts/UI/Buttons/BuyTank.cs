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
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.15f);
    private int _startLevel = 1;
    private int _currentLevel;
    private int _currentTankIndex = 1;
    private int _maxLevel = 6;
    private int _levelBuy;
    private int _factor = 3000;
    private float _progressValue = 0.25f;
    private int _maxIndex;
    private int _minLevelMerge;
    private int _fullSlider = 1;

    public int Price { get; private set; }

    private void Start()
    {
        GetData();
        PriceChecker();
        SetPositions();
    }

    public override void OnClick()
    {
        Transform position = TryGetPosition();

        if (position == null)
            return;

        if (_wallet.Money >= Price)
            Sell();

        int needNumber = _load.Get(_tanks[_currentLevel - 1].GetComponent<DragItem>().TankName, _tanks[_currentLevel - 1].GetComponent<DragItem>().Level);
        Transform tank = Instantiate(_tanks[_currentLevel - 1], _container);
        tank.GetComponent<DragItem>().SetLevel(needNumber);
        tank.transform.position = position.position;
        _storage.AddTank(tank.GetComponent<Tank>());
        ChangeValue();
        PriceChecker();
    }

    private Transform TryGetPosition()
    {
        var filter = _positions.FirstOrDefault(p => !p.GetComponent<PositionTank>().IsStay);

        if (filter == null)
            return null;

        return filter.transform;
    }

    private void SetTanksInfo()
    {
        List<int> indexes = new List<int>();
        List<int> levels = new List<int>();

        foreach (Transform position in _positions)
        {
            if (position.GetComponent<PositionTank>().Target)
            {
                int index = position.GetComponent<PositionTank>().Target.GetComponent<DragItem>().Level;
                indexes.Add(index);
                int level = position.GetComponent<PositionTank>().Target.GetComponent<DragItem>().LevelMerge;
                levels.Add(level);
            }
        }

        _maxIndex = indexes.Max();
        _minLevelMerge = levels.Min();
    }

    private void ChangeValue()
    {
        if (_slider.value < _fullSlider)
            _slider.value += _progressValue;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnSetValue());
    }

    public void SetValue()
    {
        SetTanksInfo();
        int minLevelMerge = ++_minLevelMerge;
        int maxIndex = ++_maxIndex;

        if (maxIndex >= _maxLevel)
        {
            int _allOpen = 1;
            _save.SetData(Save.AllTanksOpen, _allOpen);
        }

        if (_slider.value == _fullSlider)
        {
            if (minLevelMerge - 1 > _levelBuy)
                MoveNextLevel();
        }

        _currentLevelText.text = _levelBuy.ToString();
        _currentTankIndex = _currentLevel;
        SaveProgress();
        PriceChecker();
    }

    private void SaveProgress()
    {
        _save.SetData(Save.ProgressLevel, _currentLevel);
        _save.SetData(Save.ProgressSlider, _slider.value);
        _save.SetData(Save.LevelBuy, _levelBuy);
    }

    private void MoveNextLevel()
    {
        _slider.value = 0;
        _levelBuy++;
        _currentLevel++;

        if (_currentLevel > _maxLevel)
            _currentLevel = _startLevel;

        AddPrice();
    }

    private void Sell()
    {
        _wallet.DecreaseMoney(Price);
    }

    private void AddPrice()
    {
        Price = _levelBuy * _factor;
        _currenPriceText.text = Price.ToString();
    }

    private IEnumerator OnSetValue()
    {
        yield return _waitForSeconds;
        SetValue();
    }

    private void SetPositions()
    {
        _positions = new List<Transform>();
        int index = _load.Get(Save.Enviropment, 0);

        for (int i = 0; i < _positionsIndex[index].childCount; i++)
            _positions.Add(_positionsIndex[index].GetChild(i));

        _storage.Init(_positions);
    }

    private void GetData()
    {
        _currentLevel = _load.Get(Save.ProgressLevel, _startLevel);
        _levelBuy = _load.Get(Save.LevelBuy, _startLevel);
        _slider.value = _load.Get(Save.ProgressSlider, 0f);
        _currentLevelText.text = _levelBuy.ToString();
        AddPrice();
    }

    private void PriceChecker()
    {
        Price = _levelBuy * _factor;

        if (_wallet.Money < Price)
        {
            _button.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}