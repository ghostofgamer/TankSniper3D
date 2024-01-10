using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Breaker : MonoBehaviour
    {
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void Start()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}