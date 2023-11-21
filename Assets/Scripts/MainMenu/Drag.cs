using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Drag _drag;

    //[SerializeField] private Save _save;

    public int Id { get; private set; }

    public event UnityAction<int> LevelChanged;

    public static int CurrentNumber { get; private set; } = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerLevel>(out PlayerLevel level))
        {
            if (level.Level == GetComponent<PlayerLevel>().Level)
            {
                //if (Id < other.GetComponent<MergeTest>().Id)
                //    return;

                GameObject obj = Instantiate(_prefab, transform.position, Quaternion.identity) as GameObject;
                int levelTank = obj.GetComponent<PlayerLevel>().Level;

                if (CurrentNumber < levelTank)
                {
                    CurrentNumber = levelTank;
                    //_save.SetData(Save.Level, CurrentNumber);
                }

                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                ResetPosition();
                Debug.Log("÷òî íå òàê");
            }
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
    //private Vector3 _mousePosition;
    //private Vector3 _mOffset;
    //private float _mZCoord;

    //private float _offsetX;
    //private float _offsetY;
    //private static bool _mouseButtonReleased;

    //private Vector3 GetMousePosition()
    //{
    //    return Camera.main.WorldToScreenPoint(transform.position);
    //}
    private GameObject _selectObject;
    private float _offset = 3f;

    public Vector3 StartPosition { get; private set; }
    private int _layerNumber = 6;
    private int _layerMask;
    //private LayerMask _mask = -1;
    private RaycastHit hit;

    private void Start()
    {
        StartPosition = transform.position;
        _layerMask = 1 << _layerNumber;
        Id = GetInstanceID();
        //_save = FindObjectOfType<Save>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_selectObject == null)
            {
                hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                        return;

                    _selectObject = hit.collider.gameObject;
                    //StartPosition = _selectObject.transform.position;
                    //Cursor.visible = false;
                }
            }
        }

        //if (Input.GetMouseButton(0))
        //{
        //    if (_selectObject == null)
        //    {
        //        RaycastHit hit = CastRay();

        //        if (hit.collider != null)
        //        {
        //            if (!hit.collider.CompareTag("drag"))
        //                return;

        //            _selectObject = hit.collider.gameObject;
        //            StartPosition = _selectObject.transform.position;
        //            Cursor.visible = false;
        //        }
        //    }
        //}

        if (_selectObject == null)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            //_selectObject.transform.position = new Vector3(worldPosition.x, 3f, worldPosition.z);

            var rayOrigin = Camera.main.transform.position;
            var rayDirection = worldPosition - Camera.main.transform.position;

            RaycastHit hitInfo;

            if (Physics.Raycast(worldPosition, rayDirection, out hitInfo))
            {
                if (hitInfo.transform.tag == "Cub")
                {
                    _selectObject.transform.position = hitInfo.transform.position;
                    StartPosition = hitInfo.collider.gameObject.transform.position;
                }

                else if (/*hitInfo.transform.tag == "drag"*/hitInfo.collider.name != gameObject.name)
                {
                    Debug.Log(hitInfo.collider.name);
                    Debug.Log("èìÿ íå òî");
                    ResetPosition();
                    //if (hitInfo.collider.gameObject.GetComponent<PlayerLevel>().Level != GetComponent<PlayerLevel>().Level)
                    //    ResetPosition();
                }

                else
                {
                    ResetPosition();
                    Debug.Log("Else");
                }
            }

            //GetRaycast();
            _selectObject = null;
            //Cursor.visible = true;
        }

        if (_selectObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            _selectObject.transform.position = new Vector3(worldPosition.x, 10f, worldPosition.z);
        }
    }

    private void GetRaycast()
    {
        _layerMask = 1 << _layerNumber;
        RaycastHit hit;
        Ray ray = new Ray(_selectObject.gameObject.transform.position, -_selectObject.gameObject.transform.up);

        Physics.Raycast(ray, out hit/*, Mathf.Infinity, _layerMask*/);

        Debug.Log("ÎÁÜÅÊÒ ÑÍÈÇÓ ÒÓÒ " + hit.collider.gameObject.name);

        if (hit.collider.GetComponent<PositionTank>())
        {
            //Debug.Log(hit.collider.gameObject.name);
            Vector3 position = hit.collider.gameObject.transform.position;
            _selectObject.transform.position = new Vector3(position.x, position.y + _offset, position.z)/*hit.collider.gameObject.transform.position*/;
        }
        else if (hit.collider.GetComponent<PlayerLevel>())
        {
            _selectObject.transform.position = StartPosition;
        }
        //else if (hit.collider.GetComponent<PlayerLevel>())
        //{
        //    if (hit.collider.gameObject.GetComponent<PlayerLevel>().Level == gameObject.GetComponent<PlayerLevel>().Level)
        //    {
        //        Debug.Log(hit.collider.gameObject.GetComponent<PlayerLevel>().Level);
        //        Vector3 position = hit.collider.gameObject.transform.position;
        //        _selectObject.transform.position = new Vector3(position.x, position.y + _offset, position.z);
        //    }
        //    else
        //    {
        //        ResetPosition();
        //        Debug.Log("ðåñåòèì");
        //    }
        //}

        else
        {
            //ResetPosition();
            _selectObject.transform.position = StartPosition;
            //return;
        }
    }

    public void ResetPosition()
    {
        _selectObject.transform.position = StartPosition;
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosfar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
             Camera.main.nearClipPlane
            );

        Vector3 worldPosMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosfar);
        Vector3 worldPosMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldPosMousePosNear, worldPosMousePosFar - worldPosMousePosNear, out hit);
        return hit;
    }
}