using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Start()
    {
    }

    private void OnEnable()
    {
        //_camera = Camera.main.gameObject.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}
