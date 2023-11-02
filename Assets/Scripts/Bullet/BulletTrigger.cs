using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_bullet.Damage);

        if (other.TryGetComponent(out Player player))
            player.ApplyDamage(_bullet.Damage);
    }
}
