using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Dying = "Dying";
    private const string Rotate = "Rotate";
    private const string Shoot = "Shoot";
    private const string Walk = "Walk";

    public void Die(bool flag)
    {
        _animator.SetBool(Dying, flag);
    }

    public void TowerRotate(bool flag)
    {
        _animator.SetBool(Rotate, flag);
    }

    public void Shooting(bool flag)
    {
        _animator.SetBool(Shoot, flag);
    }

    public void Walking(bool flag)
    {
        _animator.SetBool(Walk, flag);
    }
}
