using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AbstractScreen : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Open()
    {
        SetValue(0, 1, true);
    }

    public virtual void Close()
    {
        SetValue(1, 0, false);
    }

    private void SetValue(int timeScale,int alpha,bool raycast)
    {
        Time.timeScale = timeScale;
        _canvasGroup.alpha = alpha;
        _canvasGroup.blocksRaycasts = raycast;
    }
}
