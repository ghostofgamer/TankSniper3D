using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private int _level;

    public int Level => _level;

    //public void LoadData(Saves.EnemySaveData save)
    //{
    //    transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
    //}
}
