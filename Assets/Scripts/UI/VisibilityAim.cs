using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityAim : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroupe;
    [SerializeField] private Image _startImage;

    private Coroutine _coroutine;
    private readonly float _speed = 10f;

    public void OnFadeIn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(_startImage,1,_speed,-_speed,0));
    }

    public void OnFadeOut()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Fade(_startImage, 0, -_speed, _speed,1));
    }

    IEnumerator Fade(Image image,int alpha,float speed,float speedImage,float time)
    {
        yield return new WaitForSeconds(time);

        while (_canvasGroupe.alpha != alpha)
        {
            _canvasGroupe.alpha += speed * Time.deltaTime;
            float a = _startImage.color.a;
            a += speedImage * Time.deltaTime;
            _startImage.color = new Color(_startImage.color.r, _startImage.color.g, _startImage.color.b, a);
            yield return null;
        }
    }
}