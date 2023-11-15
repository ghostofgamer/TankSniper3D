using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private readonly float _speed = 6.5f;

    private Vector3 _target;
    private float _stepSize = 15;

    public bool _isDone { get; private set; } = true;

    private void Start()
    {
        _target = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Go()
    {
        float needX = Mathf.Clamp(transform.position.x + _stepSize, -2.1f, 3.1f);
        _target = new Vector3(/*transform.position.x + _stepSize*/needX, transform.position.y, transform.position.z);
    }

    public void Hide()
    {
        StartCoroutine(GoHide());
    }

    private IEnumerator GoHide()
    {
        yield return new WaitForSeconds(1f);
        float needX = Mathf.Clamp(transform.position.x - _stepSize, -0.36f, 3.1f);
        _target = new Vector3(needX/*transform.position.x - _stepSize*/, transform.position.y, transform.position.z);
    }
}
