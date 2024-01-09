using UnityEngine;

namespace Tank3D
{
    public class RotateTankStore : MonoBehaviour
    {
        private const string MouseX = "Mouse X";

        [SerializeField] private Transform _startTransform;
        [SerializeField] private Transform _target;

        private float _speedStartRotate = 5f;
        private float _speed = 150f;
        private bool _isPressed = false;

        private void Update()
        {
            if (!_isPressed)
                ResetRotate();
        }

        private void OnMouseDrag()
        {
            float value = Input.GetAxis(MouseX);
            _target.transform.Rotate(0, -(value * _speed * Time.deltaTime), 0);
        }

        private void OnMouseDown()
        {
            _isPressed = true;
        }

        private void OnMouseUp()
        {
            _isPressed = false;
        }

        public void ResetRotate()
        {
            if (_target.transform.rotation != _startTransform.rotation)
                _target.transform.rotation = Quaternion.Lerp(_target.transform.rotation, _startTransform.rotation, _speedStartRotate * Time.deltaTime);
        }
    }
}