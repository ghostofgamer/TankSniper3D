using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Player _target;
    [SerializeField] private FlyDamage _flyDamage;
    //[SerializeField] private Transform _textPosition;

    private Coroutine _coroutine;
    private int _currentHealth;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public bool IsDying => _currentHealth <= 0;

    public event UnityAction<int,int> HealthChanged;

    public Player Target => _target;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(_flyDamage.DamageTextFly(damage));
        //StartCoroutine(DamageTextFly(damage));

        HealthChanged?.Invoke(_currentHealth,_health);

        if (_currentHealth <= 0)
            Die();
    }

    //private IEnumerator DamageTextFly(int damage)
    //{
    //    float damageText = damage;
    //    float textSize = damageText / 100;
    //    GameObject text = Instantiate(Resources.Load("DamageText"), _textPosition.localPosition, Quaternion.identity)as GameObject;
    //    text.transform.SetParent(_textPosition.transform, false);
    //    text.GetComponent<TMPro.TextMeshPro>().SetText(damageText.ToString("0"));
    //    text.name = damageText.ToString("0");
    //    text.GetComponent<TMPro.TextMeshPro>().fontSize = textSize;
    //    yield return new WaitForSeconds(1.5f);
    //    text.SetActive(false);
    //}

    private void Die()
    {
            Debug.Log("Убил");
        StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
