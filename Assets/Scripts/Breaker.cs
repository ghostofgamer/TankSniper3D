using System.Collections;
using UnityEngine;

namespace Tank3D
{
    public class Breaker : MonoBehaviour
    {
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void Start()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(OffActive());
        }

        private IEnumerator OffActive()
        {
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}