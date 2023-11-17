using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewShoot : MonoBehaviour
{
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void OnMouseDown()
    {
        _weapon.Shoot();
    }
}
