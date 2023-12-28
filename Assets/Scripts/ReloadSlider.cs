using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        SetValue();
    }

    private void OnDisable()
    {
        _slider.value = 0;
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
        _slider.value = 0;
        _slider.maxValue = 3f;
    }
}