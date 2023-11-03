using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KilledInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _killedCount;
    [SerializeField] private TMP_Text _enemyCount;
    [SerializeField] private Transform _containerEnemy;

    private int _killed;

    private void Start()
    {
        _enemyCount.text = _containerEnemy.childCount.ToString();
    }

    public void ChangeValue()
    {
        _killed++;
        _killedCount.text = _killed.ToString();
    }
}
