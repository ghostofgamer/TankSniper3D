using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    private void Start()
    {
            
    }

    public void Rotate(Vector3 target)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;

        Debug.DrawRay(transform.position, forward, Color.red);
        transform.LookAt(target);
    }
}
