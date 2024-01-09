using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class ReturnSettingsScreenButton : AbstractButton
    {
        [SerializeField] private SettingsScreen _settingsScreen;

        public override void OnClick()
        {
            _settingsScreen.Close();
            AudioListener.pause = false;
        }
    }
}