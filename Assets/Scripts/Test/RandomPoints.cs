using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoints : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    int number = 5;

    private void Update()
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_prefab, /*transform.position + */Random.insideUnitCircle * 1, Quaternion.identity);
        }
    }
}
