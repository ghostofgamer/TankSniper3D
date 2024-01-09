using UnityEngine;

public class FovMoveAim : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _fovTarget;
    [SerializeField] private float _fovStart;

    private float _speed = 1.65f;

    private void Update()
    {
        if (_camera.enabled)
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _fovTarget, _speed * Time.deltaTime);
        
        else
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _fovStart, _speed * Time.deltaTime);
    }
}
