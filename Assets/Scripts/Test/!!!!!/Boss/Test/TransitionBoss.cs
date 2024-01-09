using System.Collections;
using System.Collections.Generic;
using Tank3D;
using UnityEngine;

public class TransitionBoss : Transition
{
    [SerializeField] List<Transform> _targets;

    private int _currentTarget = 0;

    private void Update()
    {
        if (_currentTarget < _targets.Count)
        {
            if (Vector3.Distance(transform.position, _targets[_currentTarget].position) < 10)
            {
                NeedTransit = true;
                _currentTarget++;
            }
        }
    }
}