using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private AudioPlugin _audioPlugin;

    private void OnEnable()
    {
        _alarm.AlarmChanged += OnAlarm;
    }

    private void OnDisable()
    {
        _alarm.AlarmChanged -= OnAlarm;
    }

    private void OnAlarm()
    {
        if (_audioPlugin != null)
        {
            StartCoroutine(SlowStopSound());
            //    if (!GetComponent<Enemy>().IsHelicopter&& !GetComponent<Enemy>().IsBoss)
            //        _audioPlugin.StopSound();
        }

        _enemyAnimations.Shooting(true);
        NeedTransit = true;
    }

    private IEnumerator SlowStopSound()
    {
        yield return new WaitForSeconds(1f);

        if (!GetComponent<Enemy>().IsHelicopter && !GetComponent<Enemy>().IsBoss)
            _audioPlugin.StopSound();
    }

    //private void Update()
    //{
    //    if (_alarm.Warning)
    //    {
    //        _enemyAnimations.Shooting(true);
    //        NeedTransit = true;
    //    }
    //}
}
