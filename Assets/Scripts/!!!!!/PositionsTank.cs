using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsTank : MonoBehaviour
{
    [SerializeField] private Load _load;
    [SerializeField] private Transform[] _positionsIndex;
    [SerializeField] private Storage _storage;

    private List<Transform> _positions;

    //private void Awake()
    //{
    //    int index = _load.Get(Save.Enviropment, 0);
    //    Debug.Log(index);

    //    for (int i = 0; i < _positionsIndex[index].childCount; i++)
    //        _positions.Add(_positionsIndex[index].GetChild(i));


    //    //_storage.Init(_positions);
    //}

    public void Init()
    {
        int index = _load.Get(Save.Enviropment, 0);

        for (int i = 0; i < _positionsIndex[index].childCount; i++)
            _positions.Add(_positionsIndex[index].GetChild(i));
    }

    //public List GetPositions()
    //{
    //    return
    //}
}