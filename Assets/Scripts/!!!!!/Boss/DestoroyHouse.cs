using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class DestoroyHouse : State
//{
//    [SerializeField] private EnemyAnimations _enemyAnimations;
//    [SerializeField] private AudioClip _audioClip;
//    [SerializeField] private AudioSource _audioSource;

//    private void OnEnable()
//    {
//        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 13);

//        for (int i = 0; i < hitColliders.Length; i++)
//        {
//            if (hitColliders[i].gameObject.TryGetComponent(out Destroy destroy))
//                StartCoroutine(Punch(destroy));

//            //if (hitColliders[i].gameObject.TryGetComponent(out Enemy enemy))
//            //    StartCoroutine(Punch(enemy));
//        }
//    }

//    private void OnDisable()
//    {
//    }

//    private IEnumerator Punch(Destroy destroy)
//    {
//        _enemyAnimations.Shooting(true);
//        Vector3 target = new Vector3(transform.position.x, destroy.transform.position.y, transform.position.z);
//        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(target.x, 0, target.z));
//        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 3 * Time.deltaTime);
//        yield return new WaitForSeconds(1.5f);
//        _audioSource.PlayOneShot(_audioClip);
//        destroy.Destruction();
//        _enemyAnimations.Shooting(false);
//    }

//    private IEnumerator Punch(Enemy enemy)
//    {
//        if (enemy.GetComponent<EnemyShoot>())
//        {
//            _enemyAnimations.Shooting(true);
//            yield return new WaitForSeconds(1.5f);
//            enemy.TakeDamage(30);
//            _enemyAnimations.Shooting(false);
//        }
//    }
//}
