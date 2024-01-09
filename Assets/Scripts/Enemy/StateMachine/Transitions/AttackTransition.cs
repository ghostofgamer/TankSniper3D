using System.Collections;
using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private AudioSource _audioSource;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

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
            StartCoroutine(SlowStopSound());

        _enemyAnimations.Shooting(true);
        NeedTransit = true;
    }

    private IEnumerator SlowStopSound()
    {
        yield return _waitForSeconds;

        if (!GetComponent<Enemy>().IsHelicopter && !GetComponent<Enemy>().IsBoss)
            _audioSource.Stop();
    }
}