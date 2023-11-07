using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyTank : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _container;

    private List<Transform> _positions;
    private float _offset = 1.65f;

    private void Start()
    {
        _positions = new List<Transform>();

        for (int i = 0; i < _position.childCount; i++)
            _positions.Add(_position.GetChild(i));

    }

    public void OnClick()
    {
        var tank = Instantiate(_prefab, _container);
        Vector3 position = TryGetPosition();
        tank.transform.position = new Vector3(position.x, position.y + _offset, position.z);
    }

    private Vector3 TryGetPosition()
    {
        var filter = _positions.FirstOrDefault(p => !p.GetComponent<Cub>().IsStay);
        return filter.position;
    }
}
