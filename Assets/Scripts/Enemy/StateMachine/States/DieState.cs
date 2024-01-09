using UnityEngine;

namespace Tank3D
{
    public class DieState : State
    {
        [SerializeField] private Effect _effect;
        [SerializeField] private KilledInfo _killedInfo;
        [SerializeField] private float _delay = 1.65f;
        [SerializeField] private ColoringChanger _coloringChanger;
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _technique;
        [SerializeField] private Material _newMaterial;
        [SerializeField] private ParticleSystem[] effects;
        [SerializeField] private RagdollEnemy _ragdoll;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private AudioSource _audioSource;

        private void OnEnable()
        {
            Die();
        }

        private void Die()
        {
            _canvas.enabled = false;

            if (_audioSource != null)
                _audioSource.Stop();

            _animator.enabled = false;
            _ragdoll.OnRigidbody();
            _effect.PlayEffect();
            _killedInfo.ChangeValue();

            if (_technique)
                TechniqueFire();
        }

        private void TechniqueFire()
        {
            foreach (ParticleSystem effect in effects)
                effect.gameObject.SetActive(true);

            _coloringChanger.SetMaterial(_newMaterial);
        }
    }
}