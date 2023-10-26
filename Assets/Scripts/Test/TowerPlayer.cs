using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlayer : MonoBehaviour
{
    private readonly int _speed = 10;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, _speed * Time.deltaTime, 0);
        }
    }
}
