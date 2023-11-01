using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _container;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Bullet bullet = Instantiate(_prefab, _container);
            bullet.Init(_shootPosition);
            yield return _waitForSeconds;
        }
    }
}
