using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Dying = "Dying";

    public void Die(bool flag)
    {
        _animator.SetBool(Dying, flag);
    }
}
