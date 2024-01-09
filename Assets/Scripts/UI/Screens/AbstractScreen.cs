using UnityEngine;

namespace Assets.Scripts.UI.Screens
{
    [RequireComponent(typeof(CanvasGroup))]
    public class AbstractScreen : MonoBehaviour
    {
        protected CanvasGroup _canvasGroup;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void Open()
        {
            SetValue(0, 1, true, true);
        }

        public virtual void Close()
        {
            SetValue(1, 0, false, false);
        }

        private void SetValue(int timeScale, int alpha, bool raycast, bool interactable)
        {
            Time.timeScale = timeScale;
            _canvasGroup.alpha = alpha;
            _canvasGroup.blocksRaycasts = raycast;
            _canvasGroup.interactable = interactable;
        }
    }
}