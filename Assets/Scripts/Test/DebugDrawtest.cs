using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawtest : MonoBehaviour
{
    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;

        Debug.DrawRay(transform.position, forward, Color.red);
    }
}
