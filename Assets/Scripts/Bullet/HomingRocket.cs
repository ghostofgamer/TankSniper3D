using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    public enum MissileState
    {
        start,
        fly,
        end
    }

    [SerializeField] private float _speedStart;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private BulletTrigger _bulletTrigger;
    [SerializeField] private Bullet _bullet;

    private Transform _target;
    private Vector3 _startPosition;
    private float _correctVector = 1f;
    private MissileState _missileState;

    private void Start()
    {
        _target = FindObjectOfType<Player>().transform;
        _startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        switch (_missileState)
        {
            case MissileState.start:
                float startDistance = Vector3.Distance(gameObject.transform.position, _startPosition);
                gameObject.transform.Translate(Vector3.up * _speedStart * Time.deltaTime);

                if (startDistance >= 16)
                    _missileState = MissileState.fly;

                break;

            case MissileState.fly:
                gameObject.transform.Translate(Vector3.up * _speedMove * Time.deltaTime);
                Vector3 target = new Vector3(_target.transform.position.x, _target.transform.position.y + _correctVector, _target.transform.position.z);
                Vector3 _targetVector = target - gameObject.transform.position;
                gameObject.transform.up = Vector3.Slerp(gameObject.transform.up, _targetVector, _speedRotate * Time.deltaTime);
                break;
        }
    }
}