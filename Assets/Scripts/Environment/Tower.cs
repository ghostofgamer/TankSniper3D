using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class Tower : MonoBehaviour
    {
        private const int Force = 1000;

        [SerializeField] private Rigidbody _rigidbody;

        public void Fly()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.up * Force);
        }
    }
}