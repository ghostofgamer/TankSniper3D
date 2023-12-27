using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityAim : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroupe;
    [SerializeField] private CanvasGroup _canvasGroupeMobile;
    [SerializeField] private Image _startImage;
    //[SerializeField] private AudioPlugin _audioPlugin;
    [SerializeField] private AudioSource _audioSource;

    private readonly float _speed = 10f;
    private readonly float _timeFade = 0.65f;
    private readonly int _alphaFull = 1;
    private readonly int _alphaZero = 0;

    private Coroutine _coroutine;
    private CanvasGroup NeedCanvasGroup;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            NeedCanvasGroup = _canvasGroupeMobile;
        else
            NeedCanvasGroup = _canvasGroupe;
    }

    public void OnFadeIn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(NeedCanvasGroup, _alphaFull, _speed, 0, false));
    }

    public void OnFadeOut()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(NeedCanvasGroup, _alphaZero, -_speed, _timeFade, true));
    }

    IEnumerator Fade(CanvasGroup canvasGroup, int alpha, float speed, float time, bool flag)
    {
        yield return new WaitForSeconds(time);
        //_audioPlugin.PlayOneShootKey();
        _audioSource.Play();
        _startImage.gameObject.SetActive(flag);

        while (canvasGroup.alpha != alpha)
        {
            canvasGroup.alpha += speed * Time.deltaTime;
            yield return null;
        }
    }

    public void OffCanvasActive()
    {
        NeedCanvasGroup.alpha = 0;
    }
}