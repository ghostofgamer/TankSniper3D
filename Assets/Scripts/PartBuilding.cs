using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBuilding : MonoBehaviour
{
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
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
