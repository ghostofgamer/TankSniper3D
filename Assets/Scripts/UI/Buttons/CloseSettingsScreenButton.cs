using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsScreenButton : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;

    public override void OnClick()
    {
        _settingsScreen.Close();
    }
}
