using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : AbstarctScreen
{
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private TMP_Text _rewardCountText;
    [SerializeField] private int _rewardCount;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public int Reward => _rewardCount;

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
        _rewardCountText.text = _rewardCount.ToString();
        yield return _waitForSeconds;
        Open();
    }

    private void OnAllEnemysDying()
    {
        StartCoroutine(Victory());
    }
}
