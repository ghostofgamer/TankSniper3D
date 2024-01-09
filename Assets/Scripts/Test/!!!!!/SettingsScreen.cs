using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : AbstractScreen
{
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;

    private int _startSound = 1;
    private int _soundValue;
    private int _soundOff = 0;
    private int _soundOn = 1;

    public int SoundOn => _soundOn;
    public int SoundOff => _soundOff;

}
