using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel  : MonoBehaviour
{
    [SerializeField] private int _level;

    public int Level => _level;
}
