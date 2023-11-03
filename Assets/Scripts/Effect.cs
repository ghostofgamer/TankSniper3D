using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayEffect()
    {
        _effect.Play();

        if (_audio != null)
            _audio.Play();
    }
}
