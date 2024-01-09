using UnityEngine;
using UnityEngine.Events;

namespace Tank3D
{
    public class Alarm : MonoBehaviour
    {
        private Weapon _weapon;

        public event UnityAction AlertChanged;

        public void Init(Weapon weapon)
        {
            _weapon = weapon;
        }

        private void OnEnable()
        {
            _weapon.FirstShoot += OnSetAlarm;
        }

        private void OnDisable()
        {
            _weapon.FirstShoot -= OnSetAlarm;
        }

        private void OnSetAlarm()
        {
            AlertChanged?.Invoke();
        }
    }
}