using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private TankView _tankView;
    [SerializeField] private Storage _storage;
    [SerializeField] private AudioSource _audioSource;

    private BuyTank _buytank;
    private GameObject _selectObject;
    private Vector3 _startPosition;
    private int _maxIndex = 5;
    private int _layerMask;
    private int _layer = 3;
    private RaycastHit hit;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.15f);
    private Coroutine _coroutine;

    private void Start()
    {
        _layerMask = 1 << _layer;
        _layerMask = ~_layerMask;
        StartCoroutine(ChangeStorage());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TakeTank();
        }

        if (_selectObject == null)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Join();

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeStorage());
            _selectObject = null;
        }

        if (_selectObject != null)
        {
            Moving();
        }
    }

    public void Init(BuyTank buyTank)
    {
        _buytank = buyTank;
    }

    public void ResetPosition()
    {
        _selectObject.transform.position = _startPosition;
    }

    private void Join()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        var rayDirection = worldPosition - Camera.main.transform.position;
        RaycastHit hitInfo;

        if (Physics.Raycast(worldPosition, rayDirection, out hitInfo, Mathf.Infinity, _layerMask))
        {
            if (hitInfo.transform.TryGetComponent(out PositionTank positionTank))
            {
                if (!hitInfo.collider.gameObject.GetComponent<PositionTank>().IsStay)
                {
                    _selectObject.transform.position = hitInfo.transform.position;
                    _startPosition = hitInfo.collider.gameObject.transform.position;
                }

                if (hitInfo.collider.gameObject.GetComponent<PositionTank>().IsStay)
                {
                    SetNewTank(hitInfo);
                }
            }
            else
            {
                ResetPosition();
            }
        }
    }

    private void SetNewTank(RaycastHit hitInfo)
    {
        var tank = hitInfo.collider.gameObject.GetComponent<PositionTank>().Target;
        var level = tank.GetComponent<DragItem>().Level;
        var levelMerge = tank.GetComponent<DragItem>().LevelMerge;

        if (_selectObject.GetComponent<DragItem>().Level == level && _selectObject.GetComponent<DragItem>().Id != tank.GetComponent<DragItem>().Id)
        {
            int newLevel = ++level;

            if (newLevel > _maxIndex)
                StartNewCycle(ref newLevel, levelMerge);

            CreateTank(newLevel, tank);

            if (_load.Get(Save.Level, 0) < newLevel)
                Show(newLevel, levelMerge);

            StartCoroutine(LevelCheck());
        }
        else
        {
            ResetPosition();
        }
    }

    private void CreateTank(int newLevel, GameObject tank)
    {
        _audioSource.Play();
        _prefabs[newLevel].GetComponent<DragItem>().SetLevel(_selectObject.GetComponent<DragItem>().LevelMerge);
        string name = _prefabs[newLevel].GetComponent<DragItem>().TankName;
        int number = _selectObject.GetComponent<DragItem>().LevelMerge;
        _save.SetData(name, number);
        var newTank = Instantiate(_prefabs[newLevel]);
        newTank.transform.position = tank.transform.transform.position;
        _selectObject.SetActive(false);
        tank.SetActive(false);
    }

    private void StartNewCycle(ref int newLevel, int levelMerge)
    {
        newLevel = 0;
        _prefabs[newLevel].GetComponent<DragItem>().SetLevel(_selectObject.GetComponent<DragItem>().LevelMerge);

        if (_prefabs[newLevel].GetComponent<DragItem>().LevelMerge > _load.Get(Save.CurrentLevel, 0))
            Show(newLevel, levelMerge);
    }

    private void Show(int newLevel, int levelMerge)
    {
        _save.SetData(Save.Level, newLevel);
        _save.SetData(Save.Tank, newLevel);
        _tankView.NewLevel(levelMerge);
    }

    private void Moving()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Vector3 currentPosition = new Vector3(worldPosition.x, 30f, worldPosition.z);
        _selectObject.transform.position = Vector3.Lerp(_selectObject.transform.position, currentPosition, 10 * Time.deltaTime);
    }

    private void TakeTank()
    {
        if (_selectObject == null)
        {
            hit = CastRay();

            if (hit.collider != null)
            {
                if (!hit.collider.TryGetComponent(out DragItem dragItem))
                    return;

                _selectObject = hit.collider.gameObject;
                _startPosition = _selectObject.transform.position;
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosfar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
             Camera.main.nearClipPlane);

        Vector3 worldPosMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosfar);
        Vector3 worldPosMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldPosMousePosNear, worldPosMousePosFar - worldPosMousePosNear, out hit);
        return hit;
    }

    private IEnumerator ChangeStorage()
    {
        yield return _waitForSeconds;
        _storage.ListChanged();
    }

    private IEnumerator LevelCheck()
    {
        yield return _waitForSeconds;
        _buytank.SetValue();
    }
}