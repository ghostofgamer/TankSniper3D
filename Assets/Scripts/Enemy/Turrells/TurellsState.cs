using System.Collections;
using UnityEngine;

public class TurellsState : State
{
    [SerializeField] private EnemyShoot _enemyShoot;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private GameObject[] _turrels;
    [SerializeField] private ParticleSystem[] _effectsShoot;

    private Coroutine _coroutine;

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
            yield return new WaitForSeconds(1f);
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