using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    [SerializeField] private Transform _startTransform;
    [SerializeField] private GameObject _tower;

    private const string s_MouseX = "Mouse X";
    private const string s_MouseY = "Mouse Y";

    private readonly float _limitAngles = 50f;
    private readonly float _speed = 1f;

    private float vertical;
    private float horizontal;

    public void Rotate()
    {
        vertical += Input.GetAxis(s_MouseY);
        horizontal += Input.GetAxis(s_MouseX);
        transform.rotation = Quaternion.Euler(Mathf.Clamp(-vertical, -_limitAngles, _limitAngles), Mathf.Clamp(horizontal, -_limitAngles, _limitAngles), 0);
    }

    public void ResetRotate()
    {
        if (_tower.transform.rotation != _startTransform.rotation)
            transform.rotation = Quaternion.Lerp(transform.rotation, _startTransform.rotation, _speed * Time.deltaTime);
    }
}
