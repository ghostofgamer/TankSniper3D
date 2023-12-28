using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHit : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}