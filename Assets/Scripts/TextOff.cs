using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOff : MonoBehaviour
{
    private Coroutine _coroutine;

    private void Start()
    {
        StartCoroutine(OnOffActive());
    }

    private IEnumerator OnOffActive()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
