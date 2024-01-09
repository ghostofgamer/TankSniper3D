using System.Collections;
using System.Collections.Generic;
using Tank3D;
using UnityEngine;

public class MonsterGo : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private int _speed = 10;
    private List<Transform> _targets;
    private int _currentPoint = 0;

    private void Start()
    {
        _targets = new List<Transform>();

        for (int i = 0; i < _path.childCount; i++)
        {
            _targets.Add(_path.GetChild(i));
        }
    }

    private void Move()
    {
        Transform target = _targets[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        Rotate(target);
    }

    private void Rotate(Transform target)
    {
        Vector3 relativePosition = transform.position - target.position;
        Quaternion rotation = Quaternion.LookRotation(-relativePosition);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }

    private void GetNextTarget()
    {
        _currentPoint++;

        if (_currentPoint >= _targets.Count)
            _currentPoint = 0;
    }
}
