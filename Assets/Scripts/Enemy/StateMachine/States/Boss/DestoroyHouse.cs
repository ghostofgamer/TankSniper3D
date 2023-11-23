using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoroyHouse : State
{
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private void OnEnable()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.TryGetComponent(out Destroy destroy))
            {
                StartCoroutine(Punch(destroy));
            }

            if (hitColliders[i].gameObject.TryGetComponent(out Enemy enemy))
            {
                StartCoroutine(Punch(enemy));
            }
        }
    }

    private void OnDisable()
    {

    }

    private IEnumerator Punch(Destroy destroy)
    {
        _enemyAnimations.Shooting(true);
        transform.rotation = Quaternion.Slerp(transform.rotation, destroy.transform.rotation, Time.deltaTime * 8);
transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        //transform.LookAt(destroy.transform);
        yield return new WaitForSeconds(1.5f);
        destroy.GetDestroyObject();
        _enemyAnimations.Shooting(false);
    }

    private IEnumerator Punch(Enemy enemy)
    {
        if (enemy.GetComponent<EnemyShoot>())
        {
            _enemyAnimations.Shooting(true);
            transform.LookAt(enemy.transform);
            yield return new WaitForSeconds(1.5f);
            enemy.TakeDamage(30);
            _enemyAnimations.Shooting(false);
        }
    }
}
