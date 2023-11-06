using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _positionStart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_prefab, _positionStart);
        }
    }
}
