using System.Collections;
using UnityEngine;

namespace Tank3D
{
    [RequireComponent(typeof(Player))]
    public class PlayerFire : MonoBehaviour
    {
        [SerializeField] private Effect _effect;
        [SerializeField] private ParticleSystem _effectFire;

        private Player _player;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _player.Dying += OnDiyng;
        }

        private void OnDisable()
        {
            _player.Dying -= OnDiyng;
        }

        public void StewFire()
        {
            _effectFire.gameObject.SetActive(false);
        }

        private void OnDiyng()
        {
            StartCoroutine(EnableDie());
        }

        private IEnumerator EnableDie()
        {
            yield return _waitForSeconds;
            _effect.PlayEffect();
            _effectFire.gameObject.SetActive(true);
        }
    }
}