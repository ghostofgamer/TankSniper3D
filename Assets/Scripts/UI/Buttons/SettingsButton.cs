using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class SettingsButton : AbstractButton
    {
        [SerializeField] private SettingsScreen _settingsScreen;

        public override void OnClick()
        {
            _settingsScreen.Open();
            AudioListener.pause = true;
        }
    }
}