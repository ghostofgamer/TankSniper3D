using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBuilding : MonoBehaviour
{
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
    private Coroutine _coroutine;

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