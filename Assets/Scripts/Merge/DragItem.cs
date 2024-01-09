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
    [SerializeField] private string _name;
    [SerializeField] private int _defaultLevel;

    private int _id;

    public int Id => _id;

    public int Level => _level;

    public int LevelMerge => _levelMerge;

    public string TankName => _tankNameEnum.ToString();

    private void Start()
    {
        _id = GetInstanceID();
        _levelTxt.text = _levelMerge.ToString();
    }

    public void Add()
    {
        ++_levelMerge;
    }

    public void SetLevel(int level)
    {
        _levelMerge = level + 1;
        _levelTxt.text = _levelMerge.ToString();
    }
}