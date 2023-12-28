using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Transform _newGameObject;
    [SerializeField] private GameObject _oldGameObject;
    [SerializeField] private float _radius;

    private List<Transform> _destroyObjects;
    private int _destructionDamage = 10;

    public void Destruction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var hit in hitColliders)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_destructionDamage);
            }
        }

        _oldGameObject.SetActive(false);
        _newGameObject.gameObject.SetActive(true);
        _destroyObjects = new List<Transform>();

        for (int i = 0; i < _newGameObject.childCount; i++)
        {
            _destroyObjects.Add(_newGameObject.GetChild(i));
            Rigidbody rigidbody = _destroyObjects[i].gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.forward * 1000, ForceMode.Force);
        }
    }
}