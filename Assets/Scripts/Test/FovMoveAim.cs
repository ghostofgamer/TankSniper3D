using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FovMoveAim : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (_camera.enabled)
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, 30, 1.65f * Time.deltaTime);
        
        else
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, 60, 1.65f * Time.deltaTime);
    }
}
