using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTransition : Transition
{
    private void Update()
    {
       var target = GetComponent<Enemy>().Target;

        if (Vector3.Distance(target.transform.position, transform.position) <= 5)
            NeedTransit = true;
    }
}
