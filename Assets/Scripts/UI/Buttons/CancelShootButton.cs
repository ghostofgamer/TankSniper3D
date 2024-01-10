using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    public class CancelShootButton : MonoBehaviour
    {
        public bool IsCancel { get; private set; }

        private void OnEnable()
        {
            SetCanceling(false);
        }

        public void SetCanceling(bool flag)
        {
            IsCancel = flag;
        }
    }
}