using Assets.Scripts.GameEnemy.StateMachine;
using UnityEngine;

public class LookPlayerTransition : Transition
{
    private void Start()
    {

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < 13)
            NeedTransit = true;
    }
}
