using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private float _delay;

    public IEnumerator Shoot()
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            yield return _waitForSeconds;
            Bullet bullet = Instantiate(_prefab, _container);
            bullet.Init(_shootPosition);
            //yield return _waitForSeconds;
        }
    }
}
