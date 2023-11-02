using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _target;
    [SerializeField] private FlyDamage _flyDamage;

    private Coroutine _coroutine;
    private int _currentHealth;

    public Player Target => _target;
    public bool IsDying => _currentHealth <= 0;

    public event UnityAction<int,int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _currentHealth -= damage;
        _coroutine = StartCoroutine(_flyDamage.DamageTextFly(damage));
        HealthChanged?.Invoke(_currentHealth,_health);
    }
}
