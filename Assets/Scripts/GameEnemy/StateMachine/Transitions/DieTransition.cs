using UnityEngine;

namespace Assets.Scripts.GameEnemy.StateMachine.Transitions
{
    public class DieTransition : Transition
    {
        [SerializeField] private Enemy _enemy;

        private void OnEnable()
        {
            _enemy.HealthChanged += DieState;
        }

        private void OnDisable()
        {
            _enemy.HealthChanged -= DieState;
        }

        private void DieState(int currentHealth, int maxHealth)
        {
            if (currentHealth <= 0)
            {
                NeedTransit = true;
            }
        }
    }
}