using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : Weapon
{
    private readonly int _count = 4;
    private readonly float _delay = 0.1f;

    public override void SuperShoot()
    {
        MultiShoot(_count, _delay);
    }
}