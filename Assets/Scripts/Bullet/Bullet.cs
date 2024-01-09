using UnityEngine;

namespace Tank3D
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;

        public Transform ShootPosition { get; private set; }

        public int Damage => _damage;

        public void Init(Transform transform)
        {
            ShootPosition = transform;
            this.transform.position = transform.position;
            this.transform.rotation = transform.rotation;
        }
    }
}