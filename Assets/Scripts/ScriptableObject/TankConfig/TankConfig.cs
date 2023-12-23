using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTankConfig", menuName = "TankConfig/CreateNewTankConfig", order = 51)]
public class TankConfig : ScriptableObject
{
    [SerializeField] private int _level;

    public int Level => _level;
}