using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    float runningTime = 0;
    float t = 0.0f;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _limitAngles = 50f;
    [SerializeField] private float _minLimitAngles = 50f;
    [SerializeField] private float _limitAnglesY = 30f;
    [SerializeField] private float _minLimitAnglesY = 30f;
    [SerializeField] private float _cameraSpeed;
    private bool _isZoomStart = false;
    private Coroutine coroutine;
    Vector3 targetPos;
    Vector3 NewTargetPos;
    Quaternion targetRot;
    Quaternion NewtargetRot;





    private float _xRotation = 0;
    private float _yRotation = 0;



    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float minlimitX = 80; // ограничение вращени€ по Y
    public float maxlimitX = 80; // ограничение вращени€ по Y
    public float minlimitY = 80; // ограничение вращени€ по Y
    public float maxlimitY = 80; // ограничение вращени€ по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    [SerializeField]private float X, Y;







    //[SerializeField]
    //private float _mouseSensitivity = 3.0f;

    //private float _rotationY;
    //private float _rotationX;

    //[SerializeField]
    //private Transform _target;

    //[SerializeField]
    //private float _distanceFromTarget = 3.0f;

    //private Vector3 _currentRotation;
    //private Vector3 _smoothVelocity = Vector3.zero;

    //[SerializeField]
    //private float _smoothTime = 0.2f;

    //[SerializeField]
    //private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    private void Start()
    {
        //transform.position = target.position + offset;
        transform.position = targetRot * offset + target.position;
        WHAT();
        //transform.localRotation = new Quaternion(5, 5, 5, 5);
        //transform.rotation = new Quaternion(10f, 5f, 0f, 0);
        //X = transform.rotation.x;
        //X = transform.rotation.y;
        //Y = transform.rotation.y;
        //Y = transform.localRotation.x;
        Debug.Log(Y);

        //minlimitX = Mathf.Abs(minlimitX);
        //if (minlimitX > 90) minlimitX = 90;



        //offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        //_xRotation = transform.rotation.y;
        //_yRotation = transform.rotation.x;
        //Input.GetAxis(MouseY) = transform.rotation.x;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!_isZoomStart)
                RoatteNew();
            //float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
            //float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

            //_rotationY -= mouseX;
            //_rotationX -= mouseY;
            //// Apply clamping for x rotation 
            //_rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

            //Vector3 nextRotation = new Vector3(_rotationX, -_rotationY);
            //// Apply damping between rotation changes
            //_currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
            //transform.localEulerAngles = _currentRotation;
            //// Substract forward vector of the GameObject to point its forward vector to the target
            ////transform.position = _target.position - transform.forward * _distanceFromTarget;
            //transform.position = _target.position - transform.localRotation * offset/** _distanceFromTarget*/;
            ////transform.position = Vector3.Lerp(transform.position, transform.localRotation * offset + _target.position, 3 * Time.deltaTime);
            ///


            //Rotate();
        }
        else
        {
            //Y = transform.rotation.x;
            //Debug.Log(transform.rotation.x);
            //X = -transform.rotation.y;
            Stay();
        }
    }

    //private void FixedUpdate()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (!_isZoomStart)
    //            RoatteNew();
    //    }
    //    else
    //    {

    //        Stay();
    //    }

    //}

    public void RoatteNew()
    {
        //if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        //else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        //offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
        //Debug.Log("’" + X);

        X += /*transform.localEulerAngles.y + */Input.GetAxis("Mouse X")/* * sensitivity*//* * Time.deltaTime*/;
        X = Mathf.Clamp(X, -minlimitY, maxlimitY);
        Y += Input.GetAxis("Mouse Y")/* * sensitivity *//* * Time.deltaTime*/;
        Y = Mathf.Clamp(Y, -minlimitX, maxlimitX);
        //if (X < transform.rotation.x)
        //{
        //    X = transform.rotation.x;
        //}
        //if (Y < transform.rotation.y)
        //{
        //    Y = transform.rotation.y;
        //}
        Debug.Log(X);
        //Quaternion targetRotation = Quaternion.Euler(-Y, X, 0);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);
        //float playerRotationY = Mathf.Lerp(transform.localEulerAngles.y, X, Time.deltaTime * 10);
        //Vector3 targetNew = Vector3.Lerp(transform.localEulerAngles, new Vector3(-Y, X, 0), Time.deltaTime * 10);
        //Debug.Log("’" + X);

        //Quaternion newRotation = Quaternion.Euler(-Y, X, 0f);
        targetRot = Quaternion.Euler(-Y, X, 0f);

        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, _cameraSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation,   Time.deltaTime/ 0.5f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);


        //Quaternion quater = Quaternion.Slerp(transform.rotation, newRotation, _cameraSpeed * Time.deltaTime);
        //Quaternion quater = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        //Debug.Log("1" + targetRot);
        //Debug.Log(X + " и " + Y);
        //transform.rotation = quater;
        //transform.localRotation = NewtargetRot;
        transform.rotation = NewtargetRot;




        //transform.localEulerAngles = new Vector3(-Y, X, 0);
        //Vector3 newPosition = newRotation * new Vector3(0f, 0f, tmpPositionZ) + tempPositionBot;
        //transform.position = newPosition;
        //transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, new Vector3(-Y, X, 0), t);
        //transform.position = transform.localRotation * offset + target.position;

        //Vector3 velocity = new Vector3(0, 0, 0);

        //Vector3 move = Vector3.Slerp(transform.position, /*transform.localRotation*/newRotation * offset + target.position, _cameraSpeed * Time.deltaTime);
        targetPos = targetRot * offset + target.position;
        //Vector3 move = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);
        NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);

        //Vector3 move = Vector3.Slerp(transform.position, transform.rotation * offset + target.position, _cameraSpeed * Time.deltaTime);
        //transform.position = move;
        transform.position = NewTargetPos;
        //transform.position = Vector3.Lerp(transform.position, /*transform.localRotation*/newRotation * offset + target.position, _cameraSpeed * Time.deltaTime);
        //transform.position = Vector3.Slerp(transform.position, /*transform.localRotation*/newRotation * offset + target.position, Time.deltaTime/0.5f);
        //transform.position = Vector3.MoveTowards(transform.position, /*transform.localRotation*/newRotation * offset + target.position, Time.deltaTime*3f);
        //transform.position = Vector3.SmoothDamp(transform.position, /*transform.localRotation*/newRotation * offset + target.position,ref velocity, 0.1f);



        //transform.position = Vector3.Lerp(transform.position, transform.localRotation * offset + target.position, 3 * Time.deltaTime);


        //transform.position = Vector3.Lerp(transform.position, transform.localRotation * offset + target.position, 1f);
        //transform.position = Vector3.Lerp(transform.position, transform.localRotation * offset + target.position, t);
        //t += 0.5f * Time.deltaTime;
        //if (t > 1.0f)
        //{
        //    float temp = maximum;
        //    maximum = minimum;
        //    minimum = temp;
        //    t = 0.0f;
        //}
    }

    //public void Rotate()
    //{
    //    _xRotation -= Input.GetAxis(MouseY)/* * 5*/;
    //    Debug.Log(_xRotation);
    //    _xRotation = Mathf.Clamp(_xRotation, -_minLimitAnglesY, _limitAnglesY);
    //    _yRotation -= Input.GetAxis(MouseX)/* * 5*/;
    //    _yRotation = Mathf.Clamp(_yRotation, -_minLimitAngles, _limitAngles);

    //    Quaternion targetRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);

    //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);
    //    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);
    //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 130 * Time.deltaTime);
    //}

    public void Zoom()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(ZoomChanger());
    }

    private IEnumerator ZoomChanger()
    {
        _isZoomStart = true;
        yield return new WaitForSeconds(0.165f);
        _isZoomStart = false;
    }

    public void Stay()
    {
        NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        transform.rotation = NewtargetRot;
        targetPos = targetRot * offset + target.position;
        //Vector3 move = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);
        NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);

        //Vector3 move = Vector3.Slerp(transform.position, transform.rotation * offset + target.position, _cameraSpeed * Time.deltaTime);
        //transform.position = move;
        transform.position = NewTargetPos;



        //NewtargetRot = targetRot;
        //NewTargetPos = targetPos;
        //transform.rotation = NewtargetRot;
        //transform.position = NewTargetPos;



        //Debug.Log("—охр" + targetRot);
        //Debug.Log("—охр—вой"+ transform.rotation);
    }

    private void WHAT()
    {
        X += Input.GetAxis("Mouse X");
        X = Mathf.Clamp(X, -minlimitY, maxlimitY);
        Y += Input.GetAxis("Mouse Y");
        Y = Mathf.Clamp(Y, -minlimitX, maxlimitX);
        Debug.Log(X);

        targetRot = Quaternion.Euler(-Y, X, 0f);

        //NewtargetRot = Quaternion.Slerp(transform.rotation, targetRot, _cameraSpeed * Time.deltaTime);
        NewtargetRot = targetRot;

        transform.rotation = NewtargetRot;
        targetPos = targetRot * offset + target.position;
        NewTargetPos = targetPos;
        //NewTargetPos = Vector3.Slerp(transform.position, /*transform.localRotation*/targetPos, _cameraSpeed * Time.deltaTime);
        //transform.position = NewTargetPos;
        transform.position = targetPos;
    }
}