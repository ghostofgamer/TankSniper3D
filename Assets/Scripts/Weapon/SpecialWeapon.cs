using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : Weapon
{
    [SerializeField] private int _count;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _defaultPosition;

    private float _factor = 1.5f;
    private Coroutine _coroutine;

    public override void SuperShoot()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MultiShoot(_count, _delay));
    }

    private IEnumerator MultiShoot(int count, float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        for (int i = 0; i < count; i++)
        {
            if (_pool.TryGetObject(out Bullet bullet, PrefabBullet))
            {
                AudioSource.Play();
                bullet.Init(ShootPosition);
            }

            yield return waitForSeconds;
            Vector3 vector = ShootPosition.position + Random.insideUnitSphere * _factor;
            ShootPosition.position = vector;
        }

        ShootPosition.position = _defaultPosition.position;
    }
}