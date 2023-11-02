using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);

        if (other.TryGetComponent(out Player player))
            player.ApplyDamage(_damage);
    }
}
