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
        Price = _currentLevel * 10;
        _positions = new List<Transform>();
        _slider.value = _load.Get(Save.ProgressSlider, 0f);
        _currenPriceText.text = Price.ToString();
        _currentLevelText.text = _currentLevel.ToString();
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

        var tank = Instantiate(_tanks[_currentLevel - 1], _container);
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
        var tank = Instantiate(_tanks[_currentLevel - 1], _container);
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

    private int CheckPositionsLevel()
    {
        List<int> indexes = new List<int>();

        foreach (var position in _positions)
        {
            if (position.GetComponent<PositionTank>().Target)
            {
                int index = position.GetComponent<PositionTank>().Target.GetComponent<Tank>().Level;
                indexes.Add(index);
            }
        }

        if (indexes.Count > 0)
            return indexes.Min();

        else
            return 0;
        //_positions
    }

    private void ChangeValue()
    {
        int index = CheckPositionsLevel() + 1;

        if (index == _currentLevel || _slider.value != 1)
            _slider.value += 0.3f;

        Debug.Log("Merge" + index);

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
        int index = CheckPositionsLevel() + 1;
        Debug.Log("ûגאûגאûגאûגאûאûא" + index);
        if (_slider.value == 1 && index > _currentLevel)
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
        _wallet.DecreaseMoney(Price);
    }

    private void AddPrice()
    {
        Mathf.Clamp(Price = _currentLevel * 10, 0, 60);
        _currenPriceText.text = Price.ToString();
    }

    private IEnumerator OnSetValue()
    {
        yield return new WaitForSeconds(0.1f);
        SetValue();
    }
}