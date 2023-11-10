using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelConfig",menuName = "Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _rewardVictory;
    [SerializeField] private int _rewardGameOver;

    public int RewardVictory=> _rewardVictory;
    public int RewardGameOver=> _rewardGameOver;
}
