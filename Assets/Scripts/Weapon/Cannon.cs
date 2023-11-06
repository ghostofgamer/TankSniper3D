using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Weapon
{
    public override void SuperShoot()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.15f);

            if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
            {
                bullet.Init(_shootPosition);
            }
            //Shoot();
        }
    }
}
