using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : AbstractScreen
{
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;

    private int _soundValue;
    private int _soundOff = 0;
    private int _soundOn = 1;

    public int SoundOn => _soundOn;
    public int SoundOff => _soundOff;

    private void Awake()
    {
        _soundValue = _load.GetSound();
        Debug.Log("значение : " + _soundValue);
        AudioListener.pause = _soundValue == _soundOn ? false : true;
        Debug.Log(AudioListener.pause);
    }

    public void Mute()
    {
        Debug.Log("значение : " + _soundValue);
        AudioListener.pause = true;
        _save.SetSound(_soundOff);
    }

    public void PlaySound()
    {
        AudioListener.pause = false;
        _save.SetSound(_soundOn);
        Debug.Log("значение : " + _soundValue);
    }
}
