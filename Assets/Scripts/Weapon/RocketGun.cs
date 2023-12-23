using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGun : Weapon
{
    private readonly int _count = 3;
    private readonly float _delay = 0.3f;

    public override void SuperShoot()
    {
        MultiShoot(_count, _delay);
    }
}