using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBuilding : MonoBehaviour
{
    private Coroutine _coroutine;
    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    private void OnEnable()
    {
        _coroutine = StartCoroutine(OnSetActive());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator OnSetActive()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
