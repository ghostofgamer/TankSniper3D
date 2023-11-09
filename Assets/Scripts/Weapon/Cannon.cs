using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Weapon
{
    private readonly int _count = 2;

    public override void SuperShoot()
    {
        MultiShoot(_count);
    }
}
