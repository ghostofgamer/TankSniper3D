using UnityEngine;

namespace Assets.Scripts.GameEnemy
{
    public class RagdollEnemy : MonoBehaviour
    {
        private Rigidbody[] rigidbodies;

        private void Start()
        {
            rigidbodies = GetComponentsInChildren<Rigidbody>();
            DisableRigidbody();
        }

        public void EnbleRigidbody()
        {
            SetValue(false);
        }

        private void DisableRigidbody()
        {
            SetValue(true);
        }

        private void SetValue(bool flag)
        {
            foreach (Rigidbody rigidbody in rigidbodies)
                rigidbody.isKinematic = flag;
        }
    }
}