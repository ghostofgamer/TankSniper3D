using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Weapon
{
    private readonly int _count = 2;
    private readonly float _delay = 0.15f;

    public override void SuperShoot()
    {
        MultiShoot(_count, _delay);
    }
}
