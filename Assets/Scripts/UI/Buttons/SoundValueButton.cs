using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundValueButton : AbstractButton
{
    [SerializeField] private Image _mute;
    [SerializeField] private Image _unMute;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;

    private int _soundVolumeValue;
    private int _defaultValue = 1;

    private void Start()
    {
        _soundVolumeValue = _load.Get(Save.Volume, _defaultValue);

        if (_soundVolumeValue == 0)
        {
            AudioListener.volume = 0;
            _mute.gameObject.SetActive(true);
            _unMute.gameObject.SetActive(false);
        }
        else
        {
            AudioListener.volume = 1;
            _mute.gameObject.SetActive(false);
            _unMute.gameObject.SetActive(true);
        }
        //if (AudioListener.pause == true)
        //{
        //    _mute.gameObject.SetActive(true);
        //    _unMute.gameObject.SetActive(false);
        //}
        //else
        //{
        //    //_save.SetSound(_settingsScreen.SoundOn);
        //    _mute.gameObject.SetActive(false);
        //    _unMute.gameObject.SetActive(true);
        //}
    }

    public override void OnClick()
    {
        SetValue();
    }

    private void SetValue()
    {
        if (AudioListener.volume != 0)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;

        //if (AudioListener.volume > 0)
        //    AudioListener.volume = 0;
        //if (AudioListener.volume == 0)
        //    AudioListener.volume = 1;

        //AudioListener.pause = !AudioListener.pause;
        _mute.gameObject.SetActive(!_mute.gameObject.activeSelf);
        _unMute.gameObject.SetActive(!_unMute.gameObject.activeSelf);

        _soundVolumeValue = (int)AudioListener.volume;
        _save.SetData(Save.Volume, _soundVolumeValue);

        //if (AudioListener.pause == true)
        //    _save.SetData(Save.Sound, _settingsScreen.SoundOff);

        //else
        //    _save.SetData(Save.Sound, _settingsScreen.SoundOn);
    }
}
