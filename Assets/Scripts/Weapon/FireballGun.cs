using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGun : Weapon
{
    [SerializeField] private Bullet _bigFireball;

    protected ObjectPool<Bullet> _poolBigFireball;

    protected override void Start()
    {
        base.Start();
        _poolBigFireball = new ObjectPool<Bullet>(_bigFireball, _maxAmmo, _container);
        _poolBigFireball.GetAutoExpand(_autoExpand);
    }

    public override void SuperShoot()
    {
        if(_poolBigFireball.TryGetObject(out Bullet bullet, _bigFireball))
        {
            bullet.Init(_shootPosition);
        }
    }
}
