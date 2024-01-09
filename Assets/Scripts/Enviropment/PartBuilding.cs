using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enviropment
{
    public class PartBuilding : MonoBehaviour
    {
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine = StartCoroutine(DisableActive());
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator DisableActive()
        {
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}