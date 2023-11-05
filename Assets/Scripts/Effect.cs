using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private AudioSource _audio;

    private void Start()
    {
        _audio = _effect.GetComponent<AudioSource>();
    }

    public void PlayEffect()
    {
        _effect.Play();

        if (_audio != null)
            _audio.Play();
    }
}