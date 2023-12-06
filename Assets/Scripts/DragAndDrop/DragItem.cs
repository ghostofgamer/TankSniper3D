using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    [SerializeField] private int _level;

    private int _id;
    public int Id => _id;
    public int Level => _level;

    private void Start()
    {
        _id = GetInstanceID();
    }
}
