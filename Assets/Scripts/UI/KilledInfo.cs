using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KilledInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _killedCount;
    [SerializeField] private TMP_Text _enemyCount;
    [SerializeField] private Transform _containerEnemy;

    private int _killed;

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

        IsLastEnemy = _containerEnemy.childCount - _killed == 1;
        Debug.Log(IsLastEnemy);

        if (_killed == _containerEnemy.childCount)
            AllEnemysDying?.Invoke();
    }
}
