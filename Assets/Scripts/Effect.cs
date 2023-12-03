using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private AudioSource _audio;
    private AudioPlugin _audioPlugin;

    private void Start()
    {
        _audio = _effect.GetComponent<AudioSource>();
        _audioPlugin = _effect.GetComponent<AudioPlugin>();

    }

    public void PlayEffect()
    {
        //var effect = Instantiate(_effect, transform.position, Quaternion.identity);
        //effect.Play();

        _effect.Play();
        if (_audioPlugin != null)
            _audioPlugin.PlayKey();
        //if (_audio != null)
        //    _audio.Play();
    }
}
