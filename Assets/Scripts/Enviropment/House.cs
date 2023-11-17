using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private GameObject _destroyPrefab;

    private void Start()
    {
        //_destroyPrefab.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("дом");
        _health -= damage;
        if (_health <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Instantiate(_destroyPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        //_destroyPrefab.SetActive(true);
    }
}
