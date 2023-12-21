using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += DieState;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= DieState;
    }


    //private void Update()
    //{
    //    if (_enemy.IsDying)
    //        NeedTransit = true;
    //}

    private void DieState(int currentHealth,int maxHealth)
    {
        if (currentHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}