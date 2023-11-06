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

    private Transform _target;
    [SerializeField] private float _speedStart;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    private Vector3 _startPosition; 
    public MissileState _missileState;

    private void Start()
    {
        _target = FindObjectOfType<Enemy>().transform;
        _startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        switch (_missileState)
        {
            case MissileState.start:
                float startDistance = Vector3.Distance(gameObject.transform.position, _startPosition);
                gameObject.transform.Translate(Vector3.up * _speedStart * Time.deltaTime);

                if (startDistance >= 15)
                {
                    _missileState = MissileState.fly;
                }
                break;

            case MissileState.fly:
                gameObject.transform.Translate(Vector3.up * _speedMove * Time.deltaTime);
                Vector3 _targetVector = _target.transform.position - gameObject.transform.position;
                gameObject.transform.up = Vector3.Slerp(gameObject.transform.up, _targetVector, _speedRotate * Time.deltaTime);

                if (_targetVector.magnitude < 1)
                {
                    _missileState = MissileState.end;
                }
                break;

            case MissileState.end:
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
}

