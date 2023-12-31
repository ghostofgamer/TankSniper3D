using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    public enum MissileState
    {
        start,
        fly
    }

    [SerializeField] private float _speedStart;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private int _distance;
    [SerializeField] private BulletTrigger _bulletTrigger;
    [SerializeField] private Bullet _bullet;

    private Transform _target;
    private Vector3 _startPosition;
    private float _correctVector = 1f;
    private int _minDistance = 1;
    private MissileState _missileState;
    private float _maxSpeed = 35;

    private void Start()
    {
        _target = FindObjectOfType<Player>().transform;
        _startPosition = gameObject.transform.position;
    }

    private void OnEnable()
    {
        _speedMove = _maxSpeed;
    }

    private void OnDisable()
    {
        _missileState = MissileState.start;
    }


    private void Update()
    {
        switch (_missileState)
        {
            case MissileState.start:
                float startDistance = Vector3.Distance(gameObject.transform.position, _startPosition);
                gameObject.transform.Translate(Vector3.up * _speedStart * Time.deltaTime);

                if (startDistance >= _distance)
                    _missileState = MissileState.fly;

                break;

            case MissileState.fly:
                gameObject.transform.Translate(Vector3.up * _speedMove * Time.deltaTime);
                Vector3 target = new Vector3(_target.transform.position.x, _target.transform.position.y + _correctVector, _target.transform.position.z);
                Vector3 _targetVector = target - gameObject.transform.position;
                gameObject.transform.up = Vector3.Slerp(gameObject.transform.up, _targetVector, _speedRotate * Time.deltaTime);

                if (Vector3.Distance(transform.position, _target.position) < _minDistance)
                    _speedMove = 0f;
                break;
        }
    }
}