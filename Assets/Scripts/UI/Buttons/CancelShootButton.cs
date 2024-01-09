using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    public class CancelShootButton : MonoBehaviour
    {
        [SerializeField] private EventTrigger _eventTrigger;

        public bool IsCancel { get; private set; }

        private void OnEnable()
        {
            DontCancel();
        }

        public void Cancel()
        {
            IsCancel = true;
        }

        public void DontCancel()
        {
            IsCancel = false;
        }
    }
}