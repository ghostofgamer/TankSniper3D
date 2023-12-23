using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    //[SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private Effect _effect;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private float _delay = 1.65f;
    [SerializeField] private ColoringChanger _coloringChanger;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _technique;
    [SerializeField] private Material _newMaterial;
    [SerializeField] private ParticleSystem[] effects;
    [SerializeField] private AudioPlugin _audioPlugin;

    private Material[] materials;

    //private int _force = 300;

    private void OnEnable()
    {
        //StartCoroutine(Die());
        Die();
    }

    //private IEnumerator Die()
    //{
    //    if (_audioPlugin != null)
    //        _audioPlugin.StopSound();
        
    //    _animator.enabled = false;
    //    var rigidbody = GetComponent<Rigidbody>();
    //    rigidbody.isKinematic = false;
    //    _effect.PlayEffect();
    //    _killedInfo.ChangeValue();

    //    if (_technique)
    //        TechniqueFire();

    //    WaitForSeconds _waitForSeconds = new WaitForSeconds(_delay);
    //    //SetPhisics();
    //    //_enemyAnimations.Die(true);
    //    yield return _waitForSeconds;
    //    //gameObject.SetActive(false);
    //}

    private void Die()
    {
        if (_audioPlugin != null)
            _audioPlugin.StopSound();

        _animator.enabled = false;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        _effect.PlayEffect();
        _killedInfo.ChangeValue();

        if (_technique)
            TechniqueFire();

    }
    //private void SetPhisics()
    //{
    //    var rigidbody = GetComponent<Rigidbody>();
    //    rigidbody.isKinematic = false;
    //    rigidbody.AddForce(transform.up * _force, ForceMode.Force);
    //}

    private void TechniqueFire()
    {
        //var rigidbody = GetComponent<Rigidbody>();
        //rigidbody.isKinematic = false;

        foreach (ParticleSystem effect in effects)
            effect.gameObject.SetActive(true);

        _coloringChanger.SetMaterial(_newMaterial);
    }
}