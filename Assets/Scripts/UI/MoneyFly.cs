using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFly : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private List<Transform> _points;
    private Transform _target;
    private int _currentPoint = 0;
    private float _speed = 3000f;

    private void Start()
    {
        _points = new List<Transform>();

        for (int i = 0; i < _path.childCount; i++)
            _points.Add(_path.GetChild(i));
    }

    private void Update()
    {
        _target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            NextPoint();
    }

    private void NextPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Count)
            gameObject.SetActive(false);
    }
}