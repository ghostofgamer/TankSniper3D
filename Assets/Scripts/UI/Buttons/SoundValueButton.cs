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
    private int _minValue = 0;

    private void Start()
    {
        _soundVolumeValue = _load.Get(Save.Volume, _defaultValue);

        if (_soundVolumeValue == 0)
            SetStartValue(_minValue, true);
        else
            SetStartValue(_defaultValue, false);
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

        _mute.gameObject.SetActive(!_mute.gameObject.activeSelf);
        _unMute.gameObject.SetActive(!_unMute.gameObject.activeSelf);
        _soundVolumeValue = (int)AudioListener.volume;
        _save.SetData(Save.Volume, _soundVolumeValue);
    }

    private void SetStartValue(int volume, bool flag)
    {
        AudioListener.volume = volume;
        _mute.gameObject.SetActive(flag);
        _unMute.gameObject.SetActive(!flag);
    }
}