using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : AbstarctScreen
{
    [SerializeField] private KilledInfo _killedInfo;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    private void OnEnable()
    {
        _killedInfo.AllEnemysDying += OnAllEnemysDying;
    }

    private void OnDisable()
    {
        _killedInfo.AllEnemysDying -= OnAllEnemysDying;
    }


    private IEnumerator Victory()
    {
        yield return _waitForSeconds;
        Open();
    }

    private void OnAllEnemysDying()
    {
        StartCoroutine(Victory());
    }
}
