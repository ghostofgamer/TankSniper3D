using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGun : Weapon
{
    private readonly int _count = 4;

    public override void SuperShoot()
    {
        return;
        //MultiShoot(_count);
    }
}
