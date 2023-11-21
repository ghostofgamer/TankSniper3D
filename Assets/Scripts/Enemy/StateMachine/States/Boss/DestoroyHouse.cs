using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoroyHouse : State
{

    [SerializeField] private EnemyAnimations _enemyAnimations;

    private void Start()
    {
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destroy destroy))
        {
            Debug.Log("ÄÎÌÒðèããåð");
            StartCoroutine(Punch(destroy));
            transform.LookAt(destroy.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Destroy destroy))
        {
            Debug.Log("ÄÎÌ");
            destroy.GetDestroyObject();
            transform.LookAt(destroy.transform);
        }
    }

    private IEnumerator Punch(Destroy destroy)
    {
        _enemyAnimations.Shooting(true);
        yield return new WaitForSeconds(1.5f);
        destroy.GetDestroyObject();
        _enemyAnimations.Shooting(false);
    }
}
