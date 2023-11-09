using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLaser : MonoBehaviour
{
    [SerializeField] private LazerGun _laser;
    [SerializeField] private TowerRotate _towerRotate;

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //        _laser.Activate();
    //    if (Input.GetMouseButton(0))
    //        _towerRotate.Rotate();
    //    if (Input.GetMouseButtonUp(0))
    //        _laser.Deactivate();
    //}
}
