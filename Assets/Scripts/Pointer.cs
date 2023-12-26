using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _iconPointer;
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private Plane[] planes = new Plane[4];


    public Transform other;


    //public Transform target; // объект за которым надо следить
    //public Transform arrow; // стрелка

    [SerializeField] private Image _image;
    private Vector2 _pointerPosition;
    //[SerializeField] private 
    [SerializeField] private GameObject _aim;


    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Image _imageCurrent;
    [Range(100, 100000)]
    [SerializeField] private int _range;

    private Color _currentColor;
    [SerializeField] private Image _newImage;

    private Vector2[] _pointerPositions;

    private void Start()
    {
        _currentColor = _newImage.color;
    }

    private void Update()
    {
        if (!_enemy.IsDying)
        {

           //Debug.Log(Vector3.Distance(_image.transform.position, _pointerPosition));
            //if (/*Vector3.Distance(_image.transform.position, _pointerPosition) <= 0.1f*/_image.transform.position.x - _pointerPosition.x<1)
            //{
            //    Debug.Log("я на месте");
            //    Color a = new Color(_newImage.color.r, _newImage.color.g, _newImage.color.b, 0);
            //    _newImage.gameObject.SetActive(false);
            //    //_newImage.color = a;
            //}
            //else 
            //{
            //    Debug.Log("АГА");
            //    _newImage.gameObject.SetActive(true);
            //    //_newImage.color = _currentColor;
            //}

            _pointerPosition = Camera.main.WorldToScreenPoint(_target.position);
            //_imageCurrent.transform.position = Camera.main.WorldToScreenPoint(_target.position);
            _imageCurrent.transform.position = _pointerPosition;
            float r = Screen.width - _range;
            float ProcentLeft = Screen.width / 100 * 30;
            float ProcentRight = Screen.width / 100 * 30*3;

            float xRight = Screen.width/2+100;
            float xLeft = -xRight;
            //Debug.Log(xRight);
            //Debug.Log(xLeft);

            _pointerPosition.x = Mathf.Clamp(_pointerPosition.x, /*Screen.width+ _range*/_aim.transform.position.x - 145f /*ProcentLeft*/, /*ProcentRight*/ _aim.transform.position.x + 145f /*Screen.width - _range*/);
            _pointerPosition.y = Mathf.Clamp(_pointerPosition.y, _aim.transform.position.y - 145f, _aim.transform.position.y + 145f/*Screen.height - 55f*/);

            //_image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, 6 * Time.deltaTime);
            _image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, 6 * Time.deltaTime);
            //Debug.Log("Screen " + (_pointerPosition.x));
            _image.transform.LookAt(_imageCurrent.transform);
            Debug.Log(Vector3.Distance(_image.transform.position, _imageCurrent.transform.position));

            if(Vector3.Distance(_image.transform.position, _imageCurrent.transform.position) < 90)
            {
                _newImage.gameObject.SetActive(false);
            }
            else
            {
                _newImage.gameObject.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }


        ////Debug.Log("AIM " + _aim.transform.position);
        //_pointerPosition = Camera.main.WorldToScreenPoint(_target.position);
        //_pointerPosition.x = Mathf.Clamp(_pointerPosition.x, _aim.transform.position.x - 40, _aim.transform.position.x + 40f /*Screen.width 300f*/);
        //_pointerPosition.y = Mathf.Clamp(_pointerPosition.y, _aim.transform.position.y - 40f, _aim.transform.position.y + 40f/*Screen.height - 55f*/);
        ////Debug.Log("Position " + _pointerPosition.y);
        //_image.transform.position = Vector3.Lerp(_image.transform.position, _pointerPosition, 6 * Time.deltaTime);
        //_image.transform.rotation = _target.rotation;





        //Vector3 targetOnScreen = Camera.main.WorldToViewportPoint(target.position);
        //targetOnScreen.x = Mathf.Clamp01(targetOnScreen.x);
        //targetOnScreen.y = Mathf.Clamp01(targetOnScreen.y);

        //arrow.position = Camera.main.ViewportToWorldPoint(targetOnScreen);



        //if (other)
        //{
        //    Vector3 forward = other.transform.TransformDirection(Vector3.forward);
        //    Vector3 toOther = other.position - transform.position;

        //    Debug.Log(Vector3.Dot(forward, toOther));

        //    if (Vector3.Dot(forward, toOther) < 0)
        //    {

        //        print("The other transform is behind me!");
        //    }
        //}


        //if (_target != null)
        //{
        //    Vector3 fromPlayerToEnemy = transform.position - _target.position;
        //    Ray ray = new Ray(_target.position, fromPlayerToEnemy);
        //    Debug.DrawRay(_target.position, fromPlayerToEnemy,Color.red);
        //    //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        //    //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera, _planes);
        //    //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera, _planes);


        //    //for (int i = 0; i < _objects.Length; i++)
        //    //{
        //    //    var filter = _objects[i].GetComponent<MeshFilter>();
        //    //    Vector3 normal = Vector3.zero;

        //    //    if (filter && filter.mesh.normals.Length > 0)
        //    //        normal = filter.transform.TransformDirection(filter.mesh.normals[0]);
        //    //    planes[i] = new Plane(normal, transform.position);
        //    //    //var plane = new Plane(normal, transform.position);

        //    //}

        //    //float minDistance = Mathf.Infinity;
        //    //int planeIndex = 0;

        //    //for (int i = 0; i < 4; i++)
        //    //{
        //    //    if (planes[i].Raycast(ray, out float distance))
        //    //    {
        //    //        if (distance < minDistance)
        //    //        {
        //    //            minDistance = distance;
        //    //            planeIndex = i;
        //    //            Debug.Log("Plane");
        //    //        }
        //    //    }
        //    //}

        //    //minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToEnemy.magnitude);
        //    //Vector3 worldPosition = ray.GetPoint(minDistance);
        //    //_iconPointer.position = _camera.WorldToScreenPoint(worldPosition);
        //    //_iconPointer.rotation = GetIconRotation(planeIndex);

        //}
    }

   //private IEnumerator Fade(Image image, int alpha, float speed, float time, bool flag)
   // {
   //     yield return new WaitForSeconds(time);

   //     Color a = new Color(image.color.r, image.color.g, image.color.b,0);
   //     image.color = a;

   //     while ((int)a != alpha)
   //     {
   //         Color a += speed * Time.deltaTime;
   //         image.color.a =1f
   //         yield return null;
   //     }
   // }

    private Quaternion GetIconRotation(int planeIndex)
    {
        if (planeIndex == 0)
            return Quaternion.Euler(0f, 0f, 90f);

        if (planeIndex == 1)
            return Quaternion.Euler(0f, 0f, -90f);

        if (planeIndex == 2)
            return Quaternion.Euler(0f, 0f, 180f);

        if (planeIndex == 3)
            return Quaternion.Euler(0f, 0f, 0f);

        return Quaternion.identity;
    }
}