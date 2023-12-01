using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KilledInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _killedCount;
    [SerializeField] private TMP_Text _enemyCount;
    [SerializeField] private Transform _containerEnemy;
    [SerializeField] private ButtonMover _buttonMover;

    private int _killed;
    private int _lastEnemy = 1;

    public bool IsLastEnemy { get; private set; } = false;

    public event UnityAction AllEnemysDying;

    private void Start()
    {
        _enemyCount.text = _containerEnemy.childCount.ToString();
    }

    public void ChangeValue()
    {
        _killed++;
        _killedCount.text = _killed.ToString();

        IsLastEnemy = _containerEnemy.childCount - _killed == _lastEnemy;

        if (_killed == _containerEnemy.childCount)
        {
            _buttonMover.Down();
            AllEnemysDying?.Invoke();
        }
    }
}
