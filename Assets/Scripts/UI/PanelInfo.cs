using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInfo : AbstractScreen
{
    public void Open()
    {
        Change(1,true,true);
    }

    public void Close()
    {
        Change(0,false,false);
    }

    private void Change(int alpha, bool raycast, bool interactable)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.blocksRaycasts = raycast;
        _canvasGroup.interactable = interactable;
    }
}
