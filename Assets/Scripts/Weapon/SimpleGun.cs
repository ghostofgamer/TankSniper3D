using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : Weapon
{
    private readonly int _count = 1;

    public override void SuperShoot()
    {
        MultiShoot(_count);
    }
}
