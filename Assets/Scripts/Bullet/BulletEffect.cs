using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayEffect()
    {
        _explosionEffect.Play();

        if (_audio != null)
            _audio.Play();
    }
}
