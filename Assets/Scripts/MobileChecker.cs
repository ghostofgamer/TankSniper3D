using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MobileChecker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _fov;
    [SerializeField] private bool _isMenu;
    [SerializeField] private CanvasGroup _PC;
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
                Init(_mobile, _PC, _buyTanks[_mobileIndex]);
            else
                Init(_PC, _mobile, _buyTanks[_pcIndex]);
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