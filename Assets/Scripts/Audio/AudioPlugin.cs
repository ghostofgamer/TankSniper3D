using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlugin : MonoBehaviour
{
    [SerializeField] private SourceAudio _source;
    [SerializeField] private AudioDataProperty _clip;

    //private void Start()
    //{
    //    _source.Play("Music");
    //}
    public void PlayKey()
    {
        _source.Play(_clip.Key);
    }

    public void PlayOneShootKey()
    {
        _source.PlayOneShot(_clip.Key);
    }

    public void Play(string key)
    {
        _source.Play(key);
        _source.Loop = true;
    }

    public void PlayOnShoot(string key)
    {
        _source.PlayOneShot(key);
    }

    public void StopSound()
    {
        _source.Stop();
    }
}