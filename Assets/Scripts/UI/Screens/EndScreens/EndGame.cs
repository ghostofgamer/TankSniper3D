using System.Collections;
using UnityEngine;

namespace Tank3D
{
    public class EndGame : AbstractScreen
    {
        protected int Reward;
        protected Coroutine _coroutine;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

        public int ViewReward => Reward;

        protected virtual void OnEndGame()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            StartCoroutine(OpenScreen());
        }

        private IEnumerator OpenScreen()
        {
            yield return _waitForSeconds;
            Open();
        }
    }
}