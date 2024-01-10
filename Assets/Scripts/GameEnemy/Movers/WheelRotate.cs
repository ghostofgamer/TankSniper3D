using UnityEngine;

namespace Assets.Scripts.GameEnemy.Movers
{
    public class WheelRotate : MonoBehaviour
    {
        private const int Speed = 63;

        private void Update()
        {
            transform.Rotate(0, Speed * Time.deltaTime, 0);
        }
    }
}