using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    private readonly int _speed = 63;

    private void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}
