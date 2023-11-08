using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private DragAndDrop _drag;

    private int _maxLevel = 3;

    public int Id { get; private set; }

    private void Start()
    {
        Id = GetInstanceID();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerLevel>(out PlayerLevel level))
        {
            if (level.Level == GetComponent<PlayerLevel>().Level&& level.Level<_maxLevel)
            {
                if (Id < collision.gameObject.GetComponent<Merge>().Id)
                    return;

                GameObject obj = Instantiate(_prefab, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            //else
            //{
            //    Debug.Log("что не так");
            //    _drag.ResetPosition();
            //}
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<PlayerLevel>(out PlayerLevel level))
    //    {
    //        if (level.Level == GetComponent<PlayerLevel>().Level)
    //        {
    //            if (Id < other.GetComponent<Merge>().Id)
    //                return;

    //            GameObject obj = Instantiate(_prefab, transform.position, Quaternion.identity)as GameObject;
    //            Destroy(other);
    //            Destroy(gameObject);
    //            Debug.Log("триггер при мердже" + other.name);
    //        }
    //        else
    //        {
    //            Debug.Log("что не так");
    //            _drag.ResetPosition();
    //        }
    //    }
    //}
}
