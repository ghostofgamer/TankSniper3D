using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
    //[SerializeField] private GameObject _prefab;
    //[SerializeField] private Drag _drag;

    //public static int CurrentNumber { get; private set; } = 0;
    //public int Id { get; private set; }

    //public event UnityAction<int> LevelChanged;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<PlayerLevel>(out PlayerLevel level))
    //    {
    //        if (level.Level == GetComponent<PlayerLevel>().Level)
    //        {
    //            GameObject obj = Instantiate(_prefab, transform.position, Quaternion.identity) as GameObject;
    //            int levelTank = obj.GetComponent<PlayerLevel>().Level;

    //            if (CurrentNumber < levelTank)
    //            {
    //                CurrentNumber = levelTank;
    //            }

    //            other.gameObject.SetActive(false);
    //            gameObject.SetActive(false);
    //        }
    //        else
    //        {
    //            ResetPosition();
    //        }
    //    }
    //}

    //public void Delete()
    //{
    //    Destroy(gameObject);
    //}

    //private GameObject _selectObject;
    //private float _offset = 3f;

    //public Vector3 StartPosition { get; private set; }
    //private int _layerNumber = 6;
    //private int _layerMask;
    //private RaycastHit hit;

    //private void Start()
    //{
    //    StartPosition = transform.position;
    //    _layerMask = 1 << _layerNumber;
    //    Id = GetInstanceID();
    //}

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Mouse0))
    //    {
    //        if (_selectObject == null)
    //        {
    //            hit = CastRay();

    //            if (hit.collider != null)
    //            {
    //                if (!hit.collider.CompareTag("drag"))
    //                    return;

    //                _selectObject = hit.collider.gameObject;
    //            }
    //        }
    //    }

    //    if (_selectObject == null)
    //    {
    //        return;
    //    }

    //    if (Input.GetKeyUp(KeyCode.Mouse0))
    //    {
    //        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
    //        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
    //        var rayOrigin = Camera.main.transform.position;
    //        var rayDirection = worldPosition - Camera.main.transform.position;
    //        RaycastHit hitInfo;

    //        if (Physics.Raycast(worldPosition, rayDirection, out hitInfo))
    //        {
    //            if (hitInfo.transform.tag == "Cub")
    //            {
    //                _selectObject.transform.position = hitInfo.transform.position;
    //                StartPosition = hitInfo.collider.gameObject.transform.position;
    //            }

    //            else if (/*hitInfo.transform.tag == "drag"*/hitInfo.collider.name != gameObject.name)
    //            {
    //                Debug.Log(hitInfo.collider.name);
    //                ResetPosition();
    //                //if (hitInfo.collider.gameObject.GetComponent<PlayerLevel>().Level != GetComponent<PlayerLevel>().Level)
    //                //    ResetPosition();
    //            }

    //            else
    //            {
    //                ResetPosition();
    //            }
    //        }

    //        _selectObject = null;
    //    }

    //    if (_selectObject != null)
    //    {
    //        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
    //        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
    //        _selectObject.transform.position = new Vector3(worldPosition.x, 10f, worldPosition.z);
    //    }
    //}

    //private void GetRaycast()
    //{
    //    _layerMask = 1 << _layerNumber;
    //    RaycastHit hit;
    //    Ray ray = new Ray(_selectObject.gameObject.transform.position, -_selectObject.gameObject.transform.up);

    //    Physics.Raycast(ray, out hit/*, Mathf.Infinity, _layerMask*/);

    //    Debug.Log("ÎÁÜÅÊÒ ÑÍÈÇÓ ÒÓÒ " + hit.collider.gameObject.name);

    //    if (hit.collider.GetComponent<PositionTank>())
    //    {
    //        //Debug.Log(hit.collider.gameObject.name);
    //        Vector3 position = hit.collider.gameObject.transform.position;
    //        _selectObject.transform.position = new Vector3(position.x, position.y + _offset, position.z)/*hit.collider.gameObject.transform.position*/;
    //    }
    //    else if (hit.collider.GetComponent<PlayerLevel>())
    //    {
    //        _selectObject.transform.position = StartPosition;
    //    }

    //    else
    //    {
    //        _selectObject.transform.position = StartPosition;
    //    }
    //}

    //public void ResetPosition()
    //{
    //    _selectObject.transform.position = StartPosition;
    //}

    //private RaycastHit CastRay()
    //{
    //    Vector3 screenMousePosfar = new Vector3(
    //        Input.mousePosition.x,
    //        Input.mousePosition.y,
    //        Camera.main.farClipPlane
    //        );

    //    Vector3 screenMousePosNear = new Vector3(
    //        Input.mousePosition.x,
    //        Input.mousePosition.y,
    //         Camera.main.nearClipPlane
    //        );

    //    Vector3 worldPosMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosfar);
    //    Vector3 worldPosMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
    //    RaycastHit hit;
    //    Physics.Raycast(worldPosMousePosNear, worldPosMousePosFar - worldPosMousePosNear, out hit);
    //    return hit;
    //}
}