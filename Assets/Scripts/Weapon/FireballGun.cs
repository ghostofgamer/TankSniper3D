using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGun : Weapon
{
    [SerializeField] private Bullet _bigFireball;

    protected ObjectPool<Bullet> PoolBigFireballs;

    protected override void Start()
    {
        base.Start();
        PoolBigFireballs = new ObjectPool<Bullet>(_bigFireball, MaxAmmo, Container);
        PoolBigFireballs.SetAutoExpand(AutoExpand);
    }

    public override void SuperShoot()
    {
        if(PoolBigFireballs.TryGetObject(out Bullet bullet, _bigFireball))
            bullet.Init(ShootPosition);
    }
}