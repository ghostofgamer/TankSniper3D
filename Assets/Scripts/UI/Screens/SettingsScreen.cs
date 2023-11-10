using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : AbstractScreen
{
    public void Mute()
    {
        AudioListener.pause = true;
    }

    public void PlaySound()
    {
        AudioListener.pause = false;
    }
}
