using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHit : MonoBehaviour
{
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}