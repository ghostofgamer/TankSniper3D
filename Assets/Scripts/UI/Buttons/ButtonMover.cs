using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMover : MonoBehaviour
{
    private float _speed = 30f;
    private Vector3 minScale = new Vector3(0, 0, 0);
    private Vector3 maxScale;
    private float duration = 5;
    private Coroutine _coroutineScale;
    private float _maxDelay = 0.6f;
    private float _minDelay = 0f;

    private void Start()
    {
        maxScale = transform.localScale;
    }

    public void Up()
    {
        if (_coroutineScale != null)
            StopCoroutine(_coroutineScale);

        _coroutineScale = StartCoroutine(ScaleChanged(transform.localScale, maxScale, duration, _maxDelay));
    }

    public void Down()
    {
        if (_coroutineScale != null)
            StopCoroutine(_coroutineScale);

        _coroutineScale = StartCoroutine(ScaleChanged(transform.localScale, minScale, duration, _minDelay));
    }

    private IEnumerator ScaleChanged(Vector3 start, Vector3 target, float time,float delay)
    {
        yield return new WaitForSeconds(delay);
        float i = 0f;
        float rate = (1f / time) * _speed;

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(start, target, i);
            yield return null;
        }
    }
}