using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreator : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Enemy _monster;

    private void OnEnable()
    {
        _alarm.AlertChanged += AwakenMonster;
    }

    private void OnDisable()
    {
        _alarm.AlertChanged += AwakenMonster;
    }

    private void AwakenMonster()
    {
        _monster.gameObject.SetActive(true);
    }
}
