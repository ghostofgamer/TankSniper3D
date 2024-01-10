using System.Collections;
using Assets.Scripts.Environment;
using Assets.Scripts.GameEnemy.StateMachine;
using Assets.Scripts.GamePlayer;
using UnityEngine;

public class ResetTransition : Transition
{
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 13);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.TryGetComponent(out Destroy destroy) && hitColliders[i].gameObject.TryGetComponent(out Player player))
            {
                return;
            }
            else
            {
                StartCoroutine(GoMove());
            }
        }
    }

    private IEnumerator GoMove()
    {
        yield return new WaitForSeconds(1.6f);
        NeedTransit = true;
    }
}
