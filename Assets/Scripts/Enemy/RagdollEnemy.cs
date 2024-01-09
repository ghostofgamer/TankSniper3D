using UnityEngine;

public class RagdollEnemy : MonoBehaviour
{
    private Rigidbody[] rigidbodies;

    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        OffRigidbody();
    }

    public void OnRigidbody()
    {
        SetValue(false);
    }

    private void OffRigidbody()
    {
        SetValue(true);
    }

    private void SetValue(bool flag)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.isKinematic = flag;
    }
}