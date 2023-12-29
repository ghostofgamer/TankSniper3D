using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyFly : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Image _image;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _speedScale;
    [SerializeField] private float _speed;

    private List<Transform> _points;
    private Transform _target;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new List<Transform>();

        for (int i = 0; i < _path.childCount; i++)
            _points.Add(_path.GetChild(i));
    }

    private void Update()
    {
        Rect rect;
        rect = _image.rectTransform.rect;
        float width = rect.width;
        float height = rect.height;
        width = Mathf.MoveTowards(width, 105, Time.deltaTime * _speedScale);
        height = Mathf.MoveTowards(height, 105, Time.deltaTime * _speedScale);
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        //_target = _points[_currentPoint];
        _target = _targetPosition;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        Debug.Log(Vector3.Distance(transform.position, _target.position));

        if (Vector3.Distance(transform.position, _target.position) < 1)
            gameObject.SetActive(false);

        if (transform.position == _target.position)
            gameObject.SetActive(false);
        //if (transform.position == _target.position)
        //    NextPoint();
    }

    private void NextPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Count)
            gameObject.SetActive(false);
    }
}