using System.Collections;
using UnityEngine;

public class TextOff : MonoBehaviour
{
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnOffActive());
    }

    private IEnumerator OnOffActive()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}