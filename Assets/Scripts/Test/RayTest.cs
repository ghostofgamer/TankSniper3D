using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    [SerializeField] private TestWeapon testWeapon;

    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Ray ray = new Ray(transform.position, forward);

        Debug.DrawRay(transform.position, forward, Color.green);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    //Debug.Log(hit.collider.name);
        //    testWeapon.Rotate(hit.point);
        //}
    }

    public void MoveRotate()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Ray ray = new Ray(transform.position, forward);

        //Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.name);
            testWeapon.Rotate(hit.point);
        }
    }
}
