using UnityEngine;

namespace Assets.Scripts
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = _effect.GetComponent<AudioSource>();
        }

        public void PlayEffect()
        {
            if (_effect != null)
                _effect.Play();

            if (_audioSource != null)
                _audioSource.Play();
        }
    }
}