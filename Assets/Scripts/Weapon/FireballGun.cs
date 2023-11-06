using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGun : Weapon
{
    public override void SuperShoot()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            bullet.transform.localScale += new Vector3 (3,3,3);
        }
    }
}
