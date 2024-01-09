using System.Collections;
using System.Collections.Generic;
using Tank3D;
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
