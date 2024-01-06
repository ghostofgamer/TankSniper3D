using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInfo : AbstractScreen
{
    private readonly int FullAlpha = 1;
    private readonly int EmptyAlpha = 0;

    public void Open()
    {
        Change(FullAlpha, true,true);
    }

    public void Close()
    {
        Change(EmptyAlpha, false,false);
    }

    private void Change(int alpha, bool raycast, bool interactable)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.blocksRaycasts = raycast;
        _canvasGroup.interactable = interactable;
    }
}