using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private readonly int _speed = 6;

    private Coroutine _coroutine;
    private Vector3 _target;
    private float _stepSize = 5;

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
        _target = new Vector3(transform.position.x + _stepSize, transform.position.y, transform.position.z);
    }

    public void Hide()
    {
        StartCoroutine(GoHide());
    }

    private IEnumerator GoHide()
    {
        yield return new WaitForSeconds(1f);
        _target = new Vector3(transform.position.x - _stepSize, transform.position.y, transform.position.z);
    }
}
