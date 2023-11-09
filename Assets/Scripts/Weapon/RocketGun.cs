using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGun : Weapon
{
    private readonly int _count = 3;

    public override void SuperShoot()
    {
        MultiShoot(_count);
    }
}
