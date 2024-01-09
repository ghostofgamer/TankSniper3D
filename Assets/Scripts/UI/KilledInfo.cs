using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KilledInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _killedCount;
    [SerializeField] private TMP_Text _enemyCount;
    [SerializeField] private Transform _containerEnemy;

    private int _killed;
    private int _lastEnemy = 1;

    public event UnityAction AllEnemysDying;

    public bool IsLastEnemy { get; private set; } = false;

    public bool AllDie { get; private set; } = false;

    private void Start()
    {
        _enemyCount.text = _containerEnemy.childCount.ToString();
        _killed = 0;
        _killedCount.text = _killed.ToString();
    }

    public void ChangeValue()
    {
        _killed++;
        _killedCount.text = _killed.ToString();

        IsLastEnemy = _containerEnemy.childCount - _killed == _lastEnemy;

        if (_killed == _containerEnemy.childCount)
        {
            AllDie = true;
            AllEnemysDying?.Invoke();
        }
    }
}