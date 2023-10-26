using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private readonly int _speed = 65;

    public void Init(Transform transform)
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
        //this.transform.Translate(0, 0, 1);
    }

    private void Update()
    {
        transform.position += transform.forward * 10 * Time.deltaTime;
        //GetComponent<Rigidbody>().AddRelativeForce(transform.forward * _speed * Time.deltaTime, ForceMode.VelocityChange); 
    }
}
