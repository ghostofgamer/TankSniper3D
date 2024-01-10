using System.Collections;
using Assets.Scripts.GameEnemy.StateMachine;
using UnityEngine;

namespace Assets.Scripts.GameEnemy.Turrells
{
    public class TurellsState : State
    {
        [SerializeField] private EnemyShoot _enemyShoot;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform[] _shootPoints;
        [SerializeField] private GameObject[] _turrels;
        [SerializeField] private ParticleSystem[] _effectsShoot;

        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void OnEnable()
        {
            _coroutine = StartCoroutine(RandomShoot());
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private void Update()
        {
            Rotate();
        }

        private IEnumerator RandomShoot()
        {
            while (!_enemy.IsDying)
            {
                yield return _waitForSeconds;
                int randomIndex = Random.Range(0, _shootPoints.Length);
                _enemyShoot.Shooting(_shootPoints[randomIndex]);
                _effectsShoot[randomIndex].Play();
            }
        }

        private void Rotate()
        {
            foreach (var turrel in _turrels)
                turrel.transform.LookAt(Target.transform);
        }
    }
}