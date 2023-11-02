using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyShoot _enemyShoot;

    private float _speedRotation = 3f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(_enemyShoot.Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.LookAt(_target);
        //Vector3 relativePosition = transform.position - _target.position;
        //Quaternion rotation = Quaternion.LookRotation(-relativePosition);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
    }
}
