using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTankStore : MonoBehaviour
{
    //if (Input.GetKey(KeyCode.Mouse0))
    private const string MouseX = "Mouse X";
    private float _speed = 150f;

    private void Update()
    {


        //float value = Input.GetAxis(MouseX);
        //Debug.Log("Value " + value);
        transform.Rotate(0, 1, 0);

    }

    private void OnMouseDrag()
    {
        Debug.Log("11111");
        float value = Input.GetAxis(MouseX);
        Debug.Log("Value " + value);

        transform.Rotate(0, -(value * _speed * Time.deltaTime), 0);
    }
}
