using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverState : State
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speedMove = 5;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private Enemy _enemy;
    private List<Transform> _points;
    private int _currentPoint = 0;
    private float _speedRotation = 3;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _points = new List<Transform>();

        for (int i = 0; i < _path.childCount; i++)
            _points.Add(_path.GetChild(i));

        _enemyAnimations.Walking(true);
    }

    private void Update()
    {
        if (!_enemy.IsDying)
            Move();
    }

    private void Move()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speedMove * Time.deltaTime);
        Rotate(target);

        if (transform.position == target.position)
            NextPoint();
    }

    private void Rotate(Transform target)
    {
        Vector3 relativePosition = transform.position - target.position;
        Quaternion rotation = Quaternion.LookRotation(-relativePosition);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
    }

    private void NextPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Count)
            _currentPoint = 0;
    }
}