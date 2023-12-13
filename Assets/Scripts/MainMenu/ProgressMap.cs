using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressMap : Progress
{
    [SerializeField] private GameObject[] _enviropments;
    [SerializeField] private GameObject[] _points;
    [SerializeField] private GameObject[] _advancement;
    [SerializeField] private ProgressPoint[] _progressPoint;
    //[SerializeField] private GameObject[] _platforms;
    [SerializeField] private bool _isMainScene;
    [SerializeField] private BuyTank _buyTank;
    [SerializeField] private Transform[] _positions;

    private int _indexEnviropments;
    private int _maxIndexEnviropment = 2;

    private void Start()
    {
        if (_isMainScene)
        {
            _indexEnviropments = Load.Get(Save.Enviropment, _startIndex);
            SetElement(_enviropments, _indexEnviropments);
            //_buyTank.GetList(_positions[_indexEnviropments]);
        }

        ProgressPointImage();
        SetIndex();
        SetProgress();
    }

    private void SetProgress()
    {
        if (CurrentIndex > MaxIndex)
        {
            SetEnviropment();
            SetElement(_enviropments, _indexEnviropments);
        }

        SetElement(_points, CurrentIndex);
        SetElement(_advancement, _indexEnviropments);
    }

    private void SetEnviropment()
    {
        if (_isMainScene)
        {
            CurrentIndex = 0;
            _indexEnviropments++;

            if (_indexEnviropments > _maxIndexEnviropment)
                _indexEnviropments = 0;

            Save.SetData(Save.Enviropment, _indexEnviropments);
            Save.SetData(Save.Map, CurrentIndex);
        }
    }

    private void SetElement(GameObject[] gameObjects, int index)
    {
        foreach (var gameObject in gameObjects)
            gameObject.SetActive(false);

        gameObjects[index].SetActive(true);
    }

    public override void ResetMap()
    {
        if (_isMainScene)
        {
            _indexEnviropments = Load.Get(Save.Enviropment, _startIndex);
            SetElement(_enviropments, _indexEnviropments);
        }

        Save.SetData(Save.Map, 0);
        Save.SetData(Save.Enviropment, 0);
        CurrentIndex = Load.Get(Save.Map, _startIndex);
        SetElement(_points, CurrentIndex);
        SetElement(_advancement, _indexEnviropments);
    }

    private void ProgressPointImage()
    {
        foreach (var progressPoint in _progressPoint)
        {
            progressPoint.NoComplite();
        }

        CurrentIndex = Load.Get(Save.Map, _startIndex);

        for (int i = 0; i < CurrentIndex; i++)
        {
            _progressPoint[i].Complite();
        }
    }
}
