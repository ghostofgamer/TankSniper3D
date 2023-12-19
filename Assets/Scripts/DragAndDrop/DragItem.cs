using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Tanks
{
    SimpleTank,
    CannonTank,
    RocketTank,
    FireballTank,
    MissileTank,
    LazerTank
}

public class DragItem : MonoBehaviour
{

    [SerializeField] private int _level;
    [SerializeField] private TMP_Text _levelTxt;
    [SerializeField] private int _levelMerge;
    [SerializeField] private Tanks _tankNameEnum;

    private int _id;
    public int Id => _id;
    public int Level => _level;
    public int LevelMerge => _levelMerge;
    public string TankName => _tankNameEnum.ToString();


    private void Start()
    {
        //_levelMerge = Level + 1;
        //_levelMerge = 
        //Debug.Log(_tankNameEnum);
        _id = GetInstanceID();
        //Debug.Log("Провер " + _levelMerge);
        _levelTxt.text = _levelMerge.ToString();
    }

    public void Add()
    {
        ++_levelMerge;
    }

    public void SetLevel(int level)
    {
        //Debug.Log("Цифра " + level);
        _levelMerge = level + 1;
        _levelTxt.text = _levelMerge.ToString();
    }
}