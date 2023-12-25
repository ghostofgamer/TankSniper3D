using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _iconPointer;

    private void Update()
    {
        if (_target != null)
        {
            Vector3 fromPlayerToEnemy = transform.position - _target.position;
            Ray ray = new Ray(_target.position, fromPlayerToEnemy);
            //Debug.DrawRay(_target.position)
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            float minDistance = Mathf.Infinity;
            int planeIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                if (planes[i].Raycast(ray, out float distance))
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        planeIndex = i;
                    }
                }
            }

            minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToEnemy.magnitude);
            Vector3 worldPosition = ray.GetPoint(minDistance);
            _iconPointer.position = _camera.WorldToScreenPoint(worldPosition);
            _iconPointer.rotation = GetIconRotation(planeIndex);

        }
    }

    private Quaternion GetIconRotation(int planeIndex)
    {
        if (planeIndex == 0)
            return Quaternion.Euler(0f,0f,90f);

        if (planeIndex == 1)
            return Quaternion.Euler(0f,0f,-90f);

        if (planeIndex == 2)
            return Quaternion.Euler(0f,0f,180f);

        if (planeIndex == 3)
            return Quaternion.Euler(0f,0f,0f);

        return Quaternion.identity;
    }
}