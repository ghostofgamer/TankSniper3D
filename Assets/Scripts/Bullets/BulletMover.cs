using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private int _speed = 50;

        private void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
}