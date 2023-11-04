using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private Effect _effect;
    [SerializeField] private KilledInfo _killedInfo;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    private void OnEnable()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _killedInfo.ChangeValue();
        _effect.PlayEffect();
        _enemyAnimations.Die(true);
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
