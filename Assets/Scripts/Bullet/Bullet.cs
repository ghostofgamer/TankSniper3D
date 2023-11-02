using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private readonly int _speed = 50;
    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);

    private Coroutine _coroutine;

    public void Init(Transform transform)
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
        //this.transform.Translate(0, 0, 1);
    }

    private void OnEnable()
    {
        _coroutine =  StartCoroutine(DestroyBullet());  
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private IEnumerator DestroyBullet()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
