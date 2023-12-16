using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [SerializeField] private TowerRotate _towerRotate;

    public void Init(TowerRotate towerRotate)
    {
        _towerRotate = towerRotate;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Ray ray = new Ray(transform.position, forward);
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    public void MoveRotate()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Ray ray = new Ray(transform.position, forward);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.name);
            //_towerRotate.Rotate(hit.point);
            Debug.Log(hit.collider.name);
            _towerRotate.Rotate(hit.point);
        }
    }
}