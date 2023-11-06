using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private Coroutine _coroutine;
    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DestroyBullet());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator DestroyBullet()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
