using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image[] _images;
    [SerializeField] private TMP_Text _percentText;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
    private float _progress = .9f;
    private int _factor = 100;

    public void Loading(int index)
    {
        _loadingScreen.SetActive(true);
        SetImage();
        StartCoroutine(LoadAsync(index));
    }

    private IEnumerator LoadAsync(int index)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(index);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            _slider.value = loadAsync.progress;
            _percentText.text = (_slider.value * _factor).ToString();

            if (loadAsync.progress >= _progress && !loadAsync.allowSceneActivation)
            {
                yield return _waitForSeconds;
                loadAsync.allowSceneActivation = true;
            }

            yield return _waitForSeconds;
        }
    }

    private void SetImage()
    {
        foreach (var image in _images)
            image.gameObject.SetActive(false);

        _images[Random.Range(0, _images.Length)].gameObject.SetActive(true);
    }
}