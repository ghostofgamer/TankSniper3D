using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _targetStartPosition;

    //public void Init(Transform target)
    //{
    //    _target
    //}

    private void Start()
    {
        _targetStartPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(30, 100));
    }

    private void Update()
    {
        if (transform.position != _targetStartPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetStartPosition, 15 * Time.deltaTime);
        }

        else if(transform.position == _targetStartPosition)
        {
            Debug.Log("Ù˚‚Ù‚");
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, 15 * Time.deltaTime);
        }

        if (transform.position == _target.transform.position)
            gameObject.SetActive(false);
    }
}