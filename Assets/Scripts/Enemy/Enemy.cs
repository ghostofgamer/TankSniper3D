using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _currentHealth;

    private void Start()
    {
        
    }

    private void Die()
    {
        if (_health <= 0)
            Debug.Log("Убил");
    }
}
