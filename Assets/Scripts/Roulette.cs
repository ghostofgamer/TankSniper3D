using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Roulette : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private VictoryScreen _victoryScreen;

    private float _startReward;
    private int _angle;
    private int _zero = 0;
    private int _factor = 1;
    private int _double = 2;
    private int _triple = 3;
    private int _quadruple = 4;
    private int _quintuple = 5;

    public int Win { get; private set; }

    private void Start()
    {
        _startReward = _victoryScreen.ViewReward;
    }

    private void Update()
    {
        _angle = Mathf.RoundToInt(transform.eulerAngles.z);

        if (_angle <= 90 && _angle >= 65)
            _factor = _double;

        if (_angle < 65 && _angle >= _zero)
            _factor = _triple;

        if (_angle <= 360 && _angle >= 300)
            _factor = _quadruple;

        if (_angle < 300 && _angle >= 271)
            _factor = _quintuple;

        Win = (int)_startReward * _factor;
        _winText.text = Win.ToString();
    }
}