using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private string _name;

    public int Level => _level;
    public string Name => _name;
}