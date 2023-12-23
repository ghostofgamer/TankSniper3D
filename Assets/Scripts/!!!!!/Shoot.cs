using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Weapon
{
    public override void SuperShoot()
    {
        return;
    }

    public void MultiShoot(int count)
    {
        StartCoroutine(TripleShot(count));
    }

    private IEnumerator TripleShot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(0.15f);

            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
                bullet.Init(_shootPosition);
        }
    }
}