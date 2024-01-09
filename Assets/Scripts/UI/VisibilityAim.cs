using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityAim : MonoBehaviour
{
    private readonly float Speed = 10f;
    private readonly float TimeFade = 0.65f;
    private readonly int AlphaFull = 1;
    private readonly int AlphaZero = 0;

    [SerializeField] private CanvasGroup _canvasGroupe;
    [SerializeField] private CanvasGroup _canvasGroupeMobile;
    [SerializeField] private Image _startImage;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;
    private CanvasGroup _needCanvasGroup;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            _needCanvasGroup = _canvasGroupeMobile;
        else
            _needCanvasGroup = _canvasGroupe;
    }

    public void OnFadeIn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(_needCanvasGroup, AlphaFull, Speed, 0, false));
    }

    public void OnFadeOut()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(_needCanvasGroup, AlphaZero, -Speed, TimeFade, true));
    }

    public void OffCanvasActive()
    {
        _needCanvasGroup.alpha = 0;
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, int alpha, float speed, float time, bool flag)
    {
        yield return new WaitForSeconds(time);
        _audioSource.Play();
        _startImage.gameObject.SetActive(flag);

        while (canvasGroup.alpha != alpha)
        {
            canvasGroup.alpha += speed * Time.deltaTime;
            yield return null;
        }
    }
}