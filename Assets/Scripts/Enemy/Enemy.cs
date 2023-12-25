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
    //[SerializeField] private Billboard _billboard;

    private Player _target;
    private Coroutine _coroutine;
    private int _currentHealth;

    public Player Target => _target;
    public bool IsDying => _currentHealth <= 0;
    public bool IsBoss => _isBoss;
    public bool IsHelicopter => _isHelicopter;
    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _flyDamage.SetText(damage);
        //Debug.Log("ƒ¿Ã¿√ " + damage);
        //if (_coroutine != null)
        //    StopCoroutine(_coroutine);


        //_coroutine = StartCoroutine(_flyDamage.DamageTextFly(damage));
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
        _canvas.SetActive(true);
        //_billboard.enabled = true;
    }

    public void Init(Player player)
    {
        _target = player;
    }
}