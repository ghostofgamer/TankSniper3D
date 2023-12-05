using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMover : MonoBehaviour
{
    private Vector3 _target;
    private float _step = 310f;
    private float _speed = 30f;
    private float _min = -160;
    private float _max = 60;
    private Coroutine _coroutine;


    private Vector3 minScale = new Vector3(0, 0, 0);
    private Vector3 maxScale;
    private float duration = 5;
    private Coroutine _coroutineScale;


    private void Start()
    {
        maxScale = transform.localScale;
        _target = transform.position;
    }

    public void Up()
    {
        if (_coroutineScale != null)
            StopCoroutine(_coroutineScale);

        _coroutineScale = StartCoroutine(ScaleChanged(transform.localScale, maxScale, duration,0.6f));



        ////NextTarget(_step);
        //if (_coroutine != null)
        //    StopCoroutine(_coroutine);

        //_coroutine = StartCoroutine(OnUp());
    }

    public void Down()
    {
        if (_coroutineScale != null)
            StopCoroutine(_coroutineScale);

        _coroutineScale = StartCoroutine(ScaleChanged(transform.localScale, minScale, duration,0));

        //NextTarget(-_step);
    }

    public void Move()
    {
        if (transform.position != _target)
            transform.position = Vector3.MoveTowards(transform.position, _target, 100 * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
    }

    private void NextTarget(float target)
    {
        float step = Mathf.Clamp(transform.position.y + target, _min, _max);
        Debug.Log(step);
        _target = new Vector3(transform.position.x, step, transform.position.z);
    }

    private IEnumerator OnUp()
    {
        yield return new WaitForSeconds(0.1f);
        NextTarget(_step);
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