using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundValueButton : AbstractButton
{
    [SerializeField] private Image _mute;
    [SerializeField] private Image _unMute;

    [SerializeField] private AudioListener _audioListener;

    public override void OnClick()
    {
        SetValue();
    }

    private void SetValue()
    {
        AudioListener.pause = !AudioListener.pause;
        _mute.gameObject.SetActive(!_mute.gameObject.activeSelf);
        _unMute.gameObject.SetActive(!_unMute.gameObject.activeSelf);
    }
}
