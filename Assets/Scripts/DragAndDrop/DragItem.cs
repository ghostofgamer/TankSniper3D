using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private TMP_Text _levelTxt;
    [SerializeField] private int _levelMerge;

    private int _id;
    public int Id => _id;
    public int Level => _level;


    private void Start()
    {
        _id = GetInstanceID();
        Debug.Log("Провер " + _levelMerge);
        //_levelTxt.text = _levelMerge.ToString();
    }

    public void Add()
    {
        ++_levelMerge;
    }
}