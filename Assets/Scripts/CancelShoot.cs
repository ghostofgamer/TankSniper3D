using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelShoot : MonoBehaviour
{
    [SerializeField] private EventTrigger _eventTrigger;

    public bool IsCancelShoot { get; private set; }

    private void OnEnable()
    {
        DontCancel();
    }

    public void TryCancelShoot()
    {
        IsCancelShoot = true;
    }

    public void DontCancel()
    {
        IsCancelShoot = false;
    }
}