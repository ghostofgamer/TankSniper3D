using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private void OnEnable()
    {
        _alarm.AlertChanged += OnAlarm;
    }

    private void OnDisable()
    {
        _alarm.AlertChanged -= OnAlarm;
    }

    private void OnAlarm()
    {
        _enemyAnimations.Walking(true);
        NeedTransit = true;
    }
}