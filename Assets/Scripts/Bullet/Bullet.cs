using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    public Transform _shootPosition { get; private set; }
    public int Damage => _damage;

    public void Init(Transform transform)
    {
        _shootPosition = transform;
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }
}