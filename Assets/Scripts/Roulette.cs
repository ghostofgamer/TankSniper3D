using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Roulette : MonoBehaviour
{
    [SerializeField] private Transform target;
    //[SerializeField] private TMP_Text _winText;
    [SerializeField] private VictoryScreen _victoryScreen;

    private int _coef = 1;
    private int _watWeWin;
    private float _rew;

    public event UnityAction ChangeReward;

    private void Start()
    {
        _rew = _victoryScreen.ViewReward;
    }

    private void Update()
    {
        _watWeWin = Mathf.RoundToInt(transform.eulerAngles.z);

        if (_watWeWin <= 90 && _watWeWin >= 65)
        {
            _coef = 2;
        }

        if (_watWeWin < 65 && _watWeWin >= 0)
        {
            _coef = 3;
        }

        if (_watWeWin <= 360 && _watWeWin >= 300)
        {
            _coef = 4;
        }

        if (_watWeWin < 300 && _watWeWin >= 271)
        {
            _coef = 5;
        }
        //int current = 1;
        //int target = _coef;

        //if (target != current)
        //    current = target;

        //win = Mathf.Lerp(win, _rew * current, 35 * Time.deltaTime);
        //    _winText.text = win.ToString("0");
        //    Debug.Log(win);
        int win = (int)_rew * _coef;
        //_winText.text = win.ToString();
        _victoryScreen.ChangeRewardRoulette(win);


        //Debug.Log(win);
        //int needMount = Mathf.Lerp();

        //_winText.text = (_reward *= _coef).ToString();
        //switch (_watWeWin)
        //{

    }
}