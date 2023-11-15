using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] protected Save Save;
    [SerializeField] protected Load Load;

    protected int CurrentIndex;
    protected int MaxIndex = 4;

    public int _startIndex { get; private set; } = 0;

    private void Start()
    {
        SetIndex();
    }

    public int AddIndex()
    {
        return ++CurrentIndex;
    }

    protected void SetIndex()
    {
        CurrentIndex = Load.Get(Save.Map, _startIndex);
    }
}
