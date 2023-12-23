using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private AudioPlugin _audioPlugin;

    private void Start()
    {
        _audioPlugin = _effect.GetComponent<AudioPlugin>();
    }

    public void PlayEffect()
    {
        if (_effect != null)
            _effect.Play();

        if (_audioPlugin != null)
            _audioPlugin.PlayKey();
    }
}