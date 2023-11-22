using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : AttackState
{
    [SerializeField] private EnemyAnimations _enemyAnimations;

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
            yield return new WaitForSeconds(1.65f);
            Target.ApplyDamage(_damage);
        }
    }
}
