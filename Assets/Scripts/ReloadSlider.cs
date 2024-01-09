using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ReloadSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private float _maxValue = 3f;
        private float _zero = 0f;

        private void OnDisable()
        {
            _slider.value = _zero;
        }

        private void Start()
        {
            SetValue();
        }

        private void Update()
        {
            _slider.value += Time.deltaTime;
        }

        private void SetValue()
        {
            _slider.value = _zero;
            _slider.maxValue = _maxValue;
        }
    }
}