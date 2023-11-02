using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    private void OnEnable()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        Debug.Log("Убил");
        _enemyAnimations.Die(true);
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
