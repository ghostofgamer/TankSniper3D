using Assets.Scripts.GameEnemy;
using UnityEngine;

namespace Assets.Scripts
{
    public class BossCreator : MonoBehaviour
    {
        [SerializeField] private Alarm _alarm;
        [SerializeField] private Enemy _monster;

        private void OnEnable()
        {
            _alarm.AlertChanged += AwakenMonster;
        }

        private void OnDisable()
        {
            _alarm.AlertChanged += AwakenMonster;
        }

        private void AwakenMonster()
        {
            _monster.gameObject.SetActive(true);
        }
    }
}