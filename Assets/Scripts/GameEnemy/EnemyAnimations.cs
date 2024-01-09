using UnityEngine;

namespace Assets.Scripts.GameEnemy
{
    public class EnemyAnimations : MonoBehaviour
    {
        private const string Dying = "Dying";
        private const string Rotate = "Rotate";
        private const string Shoot = "Shoot";
        private const string Walk = "Walk";

        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isTank = false;

        public void Die(bool flag)
        {
            _animator.SetBool(Dying, flag);
        }

        public void TowerRotate(bool flag)
        {
            _animator.SetBool(Rotate, flag);
        }

        public void Shooting(bool flag)
        {
            _animator.SetBool(Shoot, flag);
        }

        public void Walking(bool flag)
        {
            if (!_isTank)
                _animator.SetBool(Walk, flag);
        }
    }
}