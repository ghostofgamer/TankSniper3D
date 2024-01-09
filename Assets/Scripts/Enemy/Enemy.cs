using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private FlyDamage _flyDamage;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private bool _isBoss;
    [SerializeField] private bool _isHelicopter;

    private Player _target;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    public Player Target => _target;

    public bool IsDying => _currentHealth <= 0;

    public bool IsBoss => _isBoss;

    public bool IsHelicopter => _isHelicopter;

    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        if (!IsDying)
            _flyDamage.SetText(damage);

        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
        _canvas.SetActive(true);
    }

    public void Init(Player player)
    {
        _target = player;
    }
}