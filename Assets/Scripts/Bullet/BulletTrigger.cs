using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _radius = 0.001f;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider other)
    {
        _explosionEffect.Play();
        _explosionEffect.GetComponent<AudioSource>().Play();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SetActive());
        Debug.Log("я попал в " + other.name);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius/*, 1, QueryTriggerInteraction.Collide*/);
        Debug.Log(hitColliders.Length);

        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("вокруг " + other.name);
            if (hitCollider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_bullet.Damage);
            }

            if (hitCollider.TryGetComponent(out Destroy destroy))
            {
                destroy.GetDestroyObject();
            }

            if (hitCollider.TryGetComponent(out Barrel barrel))
            {
                barrel.Explosion();
            }

            //if (hitCollider.TryGetComponent(out House house))
            //{
            //    house.Destroy();
            //}

        }

        if (other.TryGetComponent(out Player player))
            player.ApplyDamage(_bullet.Damage);
        //gameObject.SetActive(false);
    }

    private IEnumerator SetActive()
    {
        SetBullet(false);
        yield return new WaitForSeconds(0.6f);
        SetBullet(true);
        gameObject.SetActive(false);
    }

    private void SetBullet(bool flag)
    {
        GetComponent<Collider>().enabled = flag;
        _bullet.enabled = flag;

    }
}
