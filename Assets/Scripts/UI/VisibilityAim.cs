using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityAim : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroupe;
    [SerializeField] private CanvasGroup _canvasGroupeMobile;
    [SerializeField] private Image _startImage;

    private Coroutine _coroutine;
    private readonly float _speed = 10f;
    private readonly float _speedImage = 16f;
    private CanvasGroup NeedCanvasGroup;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            NeedCanvasGroup = _canvasGroupeMobile;
        }
        else
            NeedCanvasGroup = _canvasGroupe;
    }

    public void OnFadeIn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(NeedCanvasGroup, _startImage, 1, _speed, -_speedImage, 0, 0, false));
    }

    public void OnFadeOut()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(NeedCanvasGroup, _startImage, 0, -_speed, _speedImage, 0.6f, 255, true));
    }

    IEnumerator Fade(CanvasGroup canvasGroup, Image image, int alpha, float speed, float speedImage, float time, int color, bool flag)
    {
        yield return new WaitForSeconds(time);
        //_startImage.color = new Color(_startImage.color.r, _startImage.color.g, _startImage.color.b, color);
        _startImage.gameObject.SetActive(flag);
        while (canvasGroup.alpha != alpha)
        {
            canvasGroup.alpha += speed * Time.deltaTime;
            //float a = _startImage.color.a;
            //a += speedImage * Time.deltaTime;
            //_startImage.color = new Color(_startImage.color.r, _startImage.color.g, _startImage.color.b, a);
            yield return null;
        }
    }

    public void OffCanvasActive()
    {
        NeedCanvasGroup.alpha = 0;
    }
}