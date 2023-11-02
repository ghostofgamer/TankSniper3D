using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    [SerializeField] private Transform _startTransform;

    private readonly float _limitAngles = 50f;
    private readonly float _speed = 1f;

    private float vertical;
    private float horizontal;

    public void Rotate()
    {
        vertical += Input.GetAxis("Mouse Y");
        horizontal += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(Mathf.Clamp(-vertical, -_limitAngles, _limitAngles), Mathf.Clamp(horizontal, -_limitAngles, _limitAngles), 0);
    }

    public void ResetRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _startTransform.rotation, _speed * Time.deltaTime);
    }
}
