using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField]private Alarm _alarm;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private void Update()
    {
        if (_alarm.Warning)
        {
            _enemyAnimations.Shooting(true);
            NeedTransit = true;
        }
    }
}
