using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletDestroy : MonoBehaviour
    {
        private readonly WaitForSeconds WaitForSeconds = new WaitForSeconds(3f);

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine = StartCoroutine(SetActive());
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator SetActive()
        {
            yield return WaitForSeconds;
            gameObject.SetActive(false);
        }
    }
}