using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DRAG : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private TankView _tankView;

    private int _currentLevel;
    private int _maxLevel = 4;

    public static int CurrentNumber { get; private set; } = 0;

    public event UnityAction<int> LevelChanged;

    private GameObject _selectObject;
    private float _offset = 3f;

    public Vector3 StartPosition;
    private int _layerMask;
    private RaycastHit hit;

    private void Start()
    {
        _layerMask = 1 << 3;
        _layerMask = ~_layerMask;
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
                    StartPosition = _selectObject.transform.position;
                }
            }
        }

        if (_selectObject == null)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            var rayDirection = worldPosition - Camera.main.transform.position;

            RaycastHit hitInfo;

            if (Physics.Raycast(worldPosition, rayDirection, out hitInfo, Mathf.Infinity, _layerMask))
            {
                if (hitInfo.transform.tag == "Cub")
                {
                    if (!hitInfo.collider.gameObject.GetComponent<Cub>().IsStay)
                    {
                        _selectObject.transform.position = hitInfo.transform.position;
                        StartPosition = hitInfo.collider.gameObject.transform.position;
                    }

                    if (hitInfo.collider.gameObject.GetComponent<Cub>().IsStay)
                    {
                        var tank = hitInfo.collider.gameObject.GetComponent<Cub>().Target;
                        var level = tank.GetComponent<PlayerLevel>().Level;

                        if (_selectObject.GetComponent<PlayerLevel>().Level == level&& _selectObject.GetComponent<PlayerLevel>().Level<=_maxLevel)
                        {
                            var newTank = Instantiate(_prefabs[level]);
                            newTank.transform.position = tank.transform.transform.position;
                            _selectObject.SetActive(false);
                            tank.SetActive(false);
                            int newLevel = level + 1;

                            if (_load.Get(Save.Level,0 )< newLevel)
                            {
                                _save.SetData(Save.Level, newLevel);
                                _save.SetData(Save.Tank, newLevel);
                                _tankView.ViewTank();
                                Debug.Log(_load.Get(Save.Level, 0));
                            }
                        }
                        else
                        {
                            _selectObject.transform.position = StartPosition;
                        }
                    }
                }
                else
                {
                    _selectObject.transform.position = StartPosition;
                }
            }
            _selectObject = null;
        }

        if (_selectObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            Vector3 currentPosition = new Vector3(worldPosition.x, 10f, worldPosition.z);
            _selectObject.transform.position = Vector3.Lerp(_selectObject.transform.position, currentPosition, 10 * Time.deltaTime);

            //_selectObject.transform.position = new Vector3(worldPosition.x, 10f, worldPosition.z);
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