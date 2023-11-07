using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private DragAndDrop _drag;

    public int Id { get; private set; }

    private void Start()
    {
        Id = GetInstanceID();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerLevel>(out PlayerLevel level))
        {
            if (level.Level == GetComponent<PlayerLevel>().Level)
            {
                if (Id < collision.gameObject.GetComponent<Merge>().Id)
                    return;

                GameObject obj = Instantiate(_prefab, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("что не так");
                _drag.ResetPosition();
            }
        }
    }
}
