using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfig", menuName = "LevelConfig/CreateNewLevelConfig", order = 51)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _rewardVictory;
    [SerializeField] private int _rewardGameOver;
    [SerializeField] private int _levelNumber;

    public int LevelNumber => _levelNumber;
    public int RewardVictory => _rewardVictory;
    public int RewardGameOver => _rewardGameOver;
}