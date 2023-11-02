using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private void OnEnable()
    {
        _enemyAnimations.Shooting(false);
        _enemyAnimations.Die(true);
    }
}
