using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Screens
{
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
}