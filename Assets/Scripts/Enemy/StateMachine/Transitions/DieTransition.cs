using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if (_enemy.IsDying)
            NeedTransit = true;
    }
}
