using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;

    public event UnityAction<int,int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,_maxHealth);

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Жизни игрока кончились");
    }
}
