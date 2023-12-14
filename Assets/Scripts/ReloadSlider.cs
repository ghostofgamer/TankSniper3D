using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = 0;
        _slider.maxValue = 3f;
    }

    private void OnDisable()
    {
        _slider.value = 0;
    }

    private void Start()
    {
        _slider.value = 0;
        _slider.maxValue = 3f;
    }


    private void Update()
    {
        _slider.value += Time.deltaTime;   
    }
}