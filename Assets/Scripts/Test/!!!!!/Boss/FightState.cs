using Assets.Scripts.GameEnemy;
using Assets.Scripts.GameEnemy.StateMachine.States;
using System.Collections;
using UnityEngine;

public class FightState : AttackState
{
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    private int _damage = 15;

    private void OnEnable()
    {
        StartCoroutine(Destroyer());
        _enemyAnimations.Shooting(true);
    }

    private void OnDisable()
    {
        _enemyAnimations.Shooting(false);
    }

    private IEnumerator Destroyer()
    {
        while (!Target.IsDead)
        {
            _audioSource.PlayOneShot(_audioClip);
            yield return new WaitForSeconds(1.5f);
            //Target.ApplyDamage(_damage);
        }
    }
}
