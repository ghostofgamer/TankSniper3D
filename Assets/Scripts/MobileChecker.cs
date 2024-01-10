using Assets.Scripts.MergeTanks;
using Assets.Scripts.UI.Buttons;
using UnityEngine;

namespace Assets.Scripts
{
    public class MobileChecker : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _fov;
        [SerializeField] private bool _isMenu;
        [SerializeField] private CanvasGroup _pc;
        [SerializeField] private CanvasGroup _mobile;
        [SerializeField] private Merge _merge;
        [SerializeField] private BuyTank[] _buyTanks;

        private int _mobileIndex = 0;
        private int _pcIndex = 1;

        private void Awake()
        {
            if (_isMenu)
            {
                if (Application.isMobilePlatform)
                    Init(_mobile, _pc, _buyTanks[_mobileIndex]);
                else
                    Init(_pc, _mobile, _buyTanks[_pcIndex]);
            }

            if (Application.isMobilePlatform)
                _camera.fieldOfView = _fov;
            else
                return;
        }

        private void Init(CanvasGroup canvasActive, CanvasGroup canvasDeactivate, BuyTank buyTank)
        {
            canvasActive.alpha = 1;
            canvasActive.interactable = true;
            canvasActive.blocksRaycasts = true;
            canvasDeactivate.gameObject.SetActive(false);
            _merge.Init(buyTank);
        }
    }
}