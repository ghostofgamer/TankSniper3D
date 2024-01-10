using Assets.Scripts.Environment;
using Assets.Scripts.GameEnemy.StateMachine;
using UnityEngine;

public class LookHouseTransition : Transition
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destroy destroy))
        {
            transform.LookAt(destroy.transform);
            NeedTransit = true;
        }
    }
}
