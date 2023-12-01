using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewCamera : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _limitAngles = 50f;
    [SerializeField] private float _minLimitAngles = 50f;
    [SerializeField] private float _limitAnglesY = 30f;
    [SerializeField] private float _minLimitAnglesY = 30f;

    private float _xRotation = 0;
    private float _yRotation = 0;



    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    private float X, Y;







    [SerializeField]
    private float _mouseSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    private void Start()
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        //offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
        //_xRotation = transform.rotation.y;
        //_yRotation = transform.rotation.x;
        //Input.GetAxis(MouseY) = transform.rotation.x;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
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
            RoatteNew();
            //Rotate();
        }
    }

    //private void PIZDEC()
    //{
    //    float screenYdistance = 15; // отступ от края экрана

    //    float mouseX = Input.GetAxis("Mouse X");
    //    float mouseY = Input.GetAxis("Mouse Y");

    //    float rotationY = Camera.main.transform.localEulerAngles.y;
    //    float height = Camera.main.transform.position.z;

    //    //Управление зумом
    //    if (scrollWheel != 0) cameraZoom += scrollWheel * zoomSpeed;
    //    cameraZoom = Mathf.Clamp(cameraZoom, zoomMin, zoomMax);

    //    //Управление наклоном
    //    float playerY = Camera.main.WorldToScreenPoint(transform.position).y; //Кэшируем положение в стек
    //    if ((playerY <= Camera.main.pixelHeight - screenYdistance && mouseY < 0) || (playerY >= screenYdistance && mouseY > 0)) //Наклоняем камеру, если игрок в кадре
    //        rotationX -= mouseY * sensitivity;

    //    //Поддержание дистанции
    //    Vector3 position = transform.position - ((transform.position -
    //    Camera.main.transform.position).normalized * cameraZoom);
    //    position = new Vector3(position.x, transform.position.y + cameraZoom / 2, position.z); // корректировка высоты

    //    //Управление вращением и наклоном
    //    Camera.main.transform.RotateAround(transform.position, Vector3.up, mouseX);
    //    Quaternion lookRotation = Quaternion.LookRotation((transform.position + Vector3.up * cameraZoom) - Camera.main.transform.position); //Поворот в точку над игроком
    //    Camera.main.transform.position = (transform.position + Vector3.up * cameraZoom) + lookRotation * Vector3.back * cameraZoom;
    //    Camera.main.transform.localEulerAngles = new Vector3(rotationX, lookRotation.eulerAngles.y, 0);
    //}

    //private void LateUpdate()
    //{
    //    RoatteNew();
    //}



    //private void NEW()
    //{
    //    float mouseSence = 2.5f;
    //    float rotationX=0;
    //    float rotationY=0;

    //    rotationX += Input.GetAxis(MouseX) * (mouseSence);

    //    rotationY -= (Input.GetAxis("Mouse Y") * (mouseSence));
    //    //Приближаем камеру
    //    var position = Mathf.Clamp(transform.position + (Input.GetAxis("Mouse ScrollWheel") * 13), -90, 90);

    //    //Ограничиваем угол повора камеры по оси Y, если нужно
    //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
    //    //Ограничиваем угол повора камеры по оси Y, если нужно
    //    rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
    //    //Определяем позицию обьекта, вокруг которого вращаемся
    //    tempPositionBot = new Vector3(targetObj.transform.position.x,
    //                                   targetObj.transform.position.y + tmpPositionY,//Здесь определяется точка фокуса камеры
    //                                   targetObj.transform.position.z);

    //    tmpPositionZ = cameraPositionZ * 0.1f;

    //    newRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    //    newPosition = newRotation * new Vector3(0f, 0f, tmpPositionZ) + tempPositionBot;

    //    transform.rotation = newRotation;
    //    transform.position = newPosition;
    //}


    public void RoatteNew()
    {

        //if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        //else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        //offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity*Time.deltaTime;
        Y += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        Y = Mathf.Clamp(Y, -limit, limit);
        //Quaternion targetRotation = Quaternion.Euler(-Y, X, 0);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        //transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, new Vector3(-Y, X, 0), 100*Time.deltaTime);
        //transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, new Vector3(-Y, X, 0), 16*Time.deltaTime);
        //transform.position = transform.localRotation * offset + target.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.localRotation * offset + target.position, 65 * Time.deltaTime);

        //transform.position = Vector3.Lerp(transform.position, transform.localRotation * offset + target.position, 13 * Time.deltaTime);
    }

    public void Rotate()
    {
        _xRotation -= Input.GetAxis(MouseY)/* * 5*/;
        Debug.Log(_xRotation);
        _xRotation = Mathf.Clamp(_xRotation, -_minLimitAnglesY, _limitAnglesY);
        _yRotation -= Input.GetAxis(MouseX)/* * 5*/;
        _yRotation = Mathf.Clamp(_yRotation, -_minLimitAngles, _limitAngles);

        Quaternion targetRotation = Quaternion.Euler(_xRotation, -_yRotation, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 13 * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 130 * Time.deltaTime);
    }
}