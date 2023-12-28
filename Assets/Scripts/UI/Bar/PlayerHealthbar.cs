using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : Bar
{
    private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        Slider.value = Full;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    public void Init(Player player)
    {
        _player = player;
    }
}
