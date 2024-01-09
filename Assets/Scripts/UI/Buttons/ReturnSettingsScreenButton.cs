using UnityEngine;

public class ReturnSettingsScreenButton : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;

    public override void OnClick()
    {
        _settingsScreen.Close();
        AudioListener.pause = false;
    }
}