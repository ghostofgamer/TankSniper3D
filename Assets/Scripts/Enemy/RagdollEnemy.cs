using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnemy : MonoBehaviour
{
    private Rigidbody[] rigidbodies;

    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        OffRigidbody();
    }

    public void OffRigidbody()
    {
        SetValue(true);
    }

    public void OnRigidbody()
    {
        SetValue(false);
    }

    private void SetValue(bool flag)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.isKinematic = flag;
    }
}