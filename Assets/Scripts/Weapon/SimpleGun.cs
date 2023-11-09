using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : Weapon
{
    private readonly int _count = 1;
    private readonly float _delay = 0.16f;

    public override void SuperShoot()
    {
        MultiShoot(_count, _delay);
    }
}
