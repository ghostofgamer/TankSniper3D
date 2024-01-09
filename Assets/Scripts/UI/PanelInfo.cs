using Assets.Scripts.UI.Screens;

namespace Assets.Scripts.UI
{
    public class PanelInfo : AbstractScreen
    {
        private readonly int FullAlpha = 1;
        private readonly int EmptyAlpha = 0;

        public new void Open()
        {
            Change(FullAlpha, true, true);
        }

        public new void Close()
        {
            Change(EmptyAlpha, false, false);
        }

        private void Change(int alpha, bool raycast, bool interactable)
        {
            _canvasGroup.alpha = alpha;
            _canvasGroup.blocksRaycasts = raycast;
            _canvasGroup.interactable = interactable;
        }
    }
}