using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Transform _newGameObject;
    [SerializeField] private Transform[] _objects;
    [SerializeField] private GameObject _oldGameObject;

    public void GetDestroyObject()
    {
        _oldGameObject.SetActive(false);

        foreach (var house in _objects)
        {
            house.gameObject.SetActive(true);
            var rigidbody = house.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.down * 1000, ForceMode.Force);
        }

        //_newGameObject.gameObject.SetActive(true);

        //for (int i = 0; i < _newGameObject.childCount; i++)
        //{
        //    _newGameObject.GetChild(i);
        //    var rigidbody = _newGameObject.gameObject.GetComponent<Rigidbody>();
        //    rigidbody.AddForce(Vector3.forward * 1000, ForceMode.Force);
        //}
        //Instantiate(_newGameObject, transform.position, transform.rotation);
    }
}
