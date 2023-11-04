using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Transform _newGameObject;
    [SerializeField] private Transform[] _objects;
    [SerializeField] private GameObject _oldGameObject;

    private List<Transform> _destroyObjects;

    public void GetDestroyObject()
    {

        //foreach (var house in _objects)
        //{
        //    house.gameObject.SetActive(true);
        //    var rigidbody = house.gameObject.GetComponent<Rigidbody>();
        //    rigidbody.AddForce(Vector3.down * 1000, ForceMode.Force);
        //}
        _oldGameObject.SetActive(false);
        _newGameObject.gameObject.SetActive(true);
        _destroyObjects = new List<Transform>();

        for (int i = 0; i < _newGameObject.childCount; i++)
        {
            _destroyObjects.Add(_newGameObject.GetChild(i));
            Rigidbody rigidbody = _destroyObjects[i].gameObject.GetComponent<Rigidbody>();
            //rigidbody.AddExplosionForce(100f, transform.position, 15f, 3f);
            rigidbody.AddForce(Vector3.forward * 1000, ForceMode.Force);
        }
    }
}
