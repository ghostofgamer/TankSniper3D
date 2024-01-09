using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    private readonly int Speed = 63;

    private void Update()
    {
        transform.Rotate(0, Speed * Time.deltaTime, 0);
    }
}