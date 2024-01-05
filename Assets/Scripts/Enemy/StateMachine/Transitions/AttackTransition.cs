using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _alarm.AlertChanged += OnAlarm;
    }

    private void OnDisable()
    {
        _alarm.AlertChanged -= OnAlarm;
    }

    private void OnAlarm()
    {
        if (_audioSource != null)
        {
            StartCoroutine(SlowStopSound());
        }

        _enemyAnimations.Shooting(true);
        NeedTransit = true;
    }

    private IEnumerator SlowStopSound()
    {
        yield return new WaitForSeconds(1f);

        if (!GetComponent<Enemy>().IsHelicopter && !GetComponent<Enemy>().IsBoss)
            _audioSource.Stop();
    }
}