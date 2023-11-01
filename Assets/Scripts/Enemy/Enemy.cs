using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Tower _tower;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    [SerializeField] private Transform _textPosition;

    private int _currentHealth;

    public event UnityAction<int,int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        StartCoroutine(DamageTextFly());


        HealthChanged?.Invoke(_currentHealth,_health);

        if (_currentHealth <= 0)
            Die();
    }

    private IEnumerator DamageTextFly()
    {
        float damageText = Random.Range(300, 600);
        float textSize = damageText / 100;
        GameObject text = Instantiate(Resources.Load("DamageText"), _textPosition.localPosition, Quaternion.identity)as GameObject;
        text.transform.SetParent(_textPosition.transform, false);
        text.GetComponent<TMPro.TextMeshPro>().SetText(damageText.ToString("0"));
        text.name = damageText.ToString("0");
        text.GetComponent<TMPro.TextMeshPro>().fontSize = textSize;
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
    }

    private void Die()
    {
        _enemyAnimations.Die(true);
            Debug.Log("Убил");
        //gameObject.SetActive(false);
    }
}
