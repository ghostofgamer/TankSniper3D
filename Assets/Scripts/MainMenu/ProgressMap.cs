using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressMap : Progress
{
    [SerializeField] private GameObject[] _enviropments;
    [SerializeField] private GameObject[] _points;

    private int _indexEnviropments;
    private int _maxIndexEnviropment = 2;

    private void Start()
    {
        _indexEnviropments = Load.Get(Save.Enviropment, _startIndex);
        SetIndex();
        SetProgress();
    }

    private void SetProgress()
    {
        if (CurrentIndex > MaxIndex)
            SetEnviropment();

        foreach (GameObject _enviropment in _enviropments)
            _enviropment.SetActive(false);

        foreach (GameObject point in _points)
            point.SetActive(false);

        _points[CurrentIndex].SetActive(true);
        _enviropments[_indexEnviropments].SetActive(true);
    }

    private void SetEnviropment()
    {
        CurrentIndex = 0;
        _indexEnviropments++;

        if (_indexEnviropments > _maxIndexEnviropment)
            _indexEnviropments = 0;

        Save.SetData(Save.Enviropment, _indexEnviropments);
    }
}
