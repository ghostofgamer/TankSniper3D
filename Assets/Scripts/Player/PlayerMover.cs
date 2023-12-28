using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;

    private readonly float _speed = 10f;

    private Vector3 _target;
    private float _stepSize = 5f;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.6f);

    public bool _isHidden { get; private set; } = true;

    private void Start()
    {
        _target = transform.position;
    }

    private void Update()
    {
        if (transform.position != _target)
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Go()
    {
        _target = new Vector3(GetTarget(_stepSize), transform.position.y, transform.position.z);
        _isHidden = false;
    }

    public void Hide()
    {
        StartCoroutine(GoHide());
    }

    private IEnumerator GoHide()
    {
        yield return _waitForSeconds;
        _target = new Vector3(GetTarget(-_stepSize), transform.position.y, transform.position.z);
        _isHidden = true;
    }

    private float GetTarget(float step)
    {
        return Mathf.Clamp(transform.position.x + step, _minPositionX, _maxPositionX);
    }
}