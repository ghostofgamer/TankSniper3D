using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColliderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Триггер" + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("соллизия" + collision.gameObject.name);
    }
}
