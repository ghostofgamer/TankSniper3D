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

        SetElement(_enviropments, _indexEnviropments);
        SetElement(_points, CurrentIndex);
    }

    private void SetEnviropment()
    {
        CurrentIndex = 0;
        _indexEnviropments++;

        if (_indexEnviropments > _maxIndexEnviropment)
            _indexEnviropments = 0;

        Save.SetData(Save.Enviropment, _indexEnviropments);
        Save.SetData(Save.Map, CurrentIndex);
    }

    private void SetElement(GameObject[] gameObjects, int index)
    {
        foreach (var gameObject in gameObjects)
            gameObject.SetActive(false);

        gameObjects[index].SetActive(true);
    }
}
