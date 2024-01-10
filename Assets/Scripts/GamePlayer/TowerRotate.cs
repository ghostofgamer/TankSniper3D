using UnityEngine;

namespace Assets.Scripts.GamePlayer
{
    public class TowerRotate : MonoBehaviour
    {
        private readonly float Speed = 1f;

        [SerializeField] private GameObject _tower;
        [SerializeField] private Transform _startTransform;

        public void Rotate(Vector3 target)
        {
            _tower.transform.LookAt(target);
        }

        public void Return()
        {
            if (_tower.transform.rotation != _startTransform.rotation)
                _tower.transform.rotation = Quaternion.Lerp(_tower.transform.rotation, _startTransform.rotation, Speed * Time.deltaTime);
        }
    }
}