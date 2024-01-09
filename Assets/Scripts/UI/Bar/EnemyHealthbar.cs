using UnityEngine;

public class EnemyHealthbar : Bar
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnValueChanged;
        Slider.value = Full;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnValueChanged;
    }
}