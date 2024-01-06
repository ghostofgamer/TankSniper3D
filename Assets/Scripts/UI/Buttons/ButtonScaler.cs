using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour
{
    private float _speed = 30f;
    private Vector3 _minScale = new Vector3(0, 0, 0);
    private Vector3 _maxScale;
    private float _duration = 5;
    private Coroutine _coroutineScale;
    private float _maxDelay = 0.6f;
    private float _minDelay = 0f;
    private float _time = 1f;

    private void Start()
    {
        _maxScale = transform.localScale;
    }

    public void Up()
    {
        if (_coroutineScale != null)
            StopCoroutine(_coroutineScale);

        _coroutineScale = StartCoroutine(ScaleChanged(transform.localScale, _maxScale, _duration, _maxDelay));
    }

    public void Down()
    {
        if (_coroutineScale != null)
            StopCoroutine(_coroutineScale);

        _coroutineScale = StartCoroutine(ScaleChanged(transform.localScale, _minScale, _duration, _minDelay));
    }

    private IEnumerator ScaleChanged(Vector3 start, Vector3 target, float duration,float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
        yield return waitForSeconds;
        float i = 0f;
        float rate = (_time / duration) * _speed;

        while (i < _time)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(start, target, i);
            yield return null;
        }
    }
}