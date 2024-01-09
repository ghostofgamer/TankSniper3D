using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Bar
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;

        protected float Full = 1;

        public void OnValueChanged(int value, int maxValue)
        {
            Slider.value = (float)value / maxValue;
        }
    }
}