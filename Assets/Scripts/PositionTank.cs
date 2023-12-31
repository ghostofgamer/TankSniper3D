using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTank : MonoBehaviour
{
    public bool IsStay { get; private set; } = false;
    public GameObject Target { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out DragItem dragItem))
            SetTarget(true, dragItem.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DragItem dragItem))
            SetTarget(false, null);
    }

    private void SetTarget(bool isStay,GameObject target)
    {
        IsStay = isStay;
        Target = target;
    }
}