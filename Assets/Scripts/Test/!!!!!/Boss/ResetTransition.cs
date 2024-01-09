using System.Collections;
using System.Collections.Generic;
using Tank3D;
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
