using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
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
        _layerMask = 1 << _layerNumber;
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
                    Debug.Log(hit.collider.gameObject.name);
                    if (!hit.collider.CompareTag("drag"))
                        return;

                    _selectObject = hit.collider.gameObject;
                    StartPosition = _selectObject.transform.position;
                    Cursor.visible = false;
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
            GetRaycast();
            _selectObject = null;
            Cursor.visible = true;
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

        if (hit.collider.GetComponent<Cub>())
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
        //        Debug.Log("נוסועטל");
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


    //private void OnMouseDown()
    //{
    //    //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
    //    //{
    //    //    Debug.Log(hit.collider.gameObject.name);
    //    //}
    //    //Debug.Log("םאזאכ");


    //    //if (_selectObject == null)
    //    //{
    //    //    RaycastHit hit = CastRay();

    //    //    if (hit.collider != null)
    //    //    {
    //    //        if (!hit.collider.CompareTag("drag"))
    //    //            return;

    //    //        _selectObject = hit.collider.gameObject;
    //    //        StartPosition = _selectObject.transform.position;
    //    //        Cursor.visible = false;
    //    //    }
    //    //}








    //    //_mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    //    //_mOffset = gameObject.transform.position - GetMouseWorldPos();
    //    //_mouseButtonReleased = false;
    //    //_offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
    //    //_offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).z - transform.position.z;
    //    //_mousePosition = Input.mousePosition - GetMousePosition();
    //}

    //private void OnMouseDrag()
    //{
    //    //transform.position = GetMouseWorldPos() + _mOffset;
    //    //_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    //transform.position = new Vector3(_mousePosition.x - _offsetX, _mousePosition.z - _offsetY);
    //    //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    //}

    //private void OnMouseUp()
    //{
    //    //Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
    //    //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
    //    ////_selectObject.transform.position = new Vector3(worldPosition.x, 3f, worldPosition.z);
    //    //GetRaycast();
    //    //_selectObject = null;
    //    //Cursor.visible = true;





    //    //_mouseButtonReleased = true;
    //}

    //private Vector3 GetMouseWorldPos()
    //{
    //    Vector3 mousePoint = Input.mousePosition;
    //    mousePoint.z = _mZCoord;
    //    return Camera.main.ScreenToWorldPoint(mousePoint);
    //}
}