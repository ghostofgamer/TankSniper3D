using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject _newGameObject;
    [SerializeField] private GameObject _oldGameObject;
    [SerializeField] private GameObject _Roof;
    [SerializeField] private GameObject _newRoof;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            GetDestroyObject();
    }

    private void GetDestroyObject()
    {
        _newGameObject.SetActive(true);
        Instantiate(_newGameObject, transform.position, transform.rotation);
        _oldGameObject.SetActive(false);
    }
}
