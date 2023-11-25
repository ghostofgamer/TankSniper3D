using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGun : Weapon
{
    [SerializeField] private Bullet _bigFireball;

    public override void SuperShoot()
    {
        BigShoot(_bigFireball);
    }
}
