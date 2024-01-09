using UnityEngine;

namespace Assets.Scripts.GameEnemy.Movers
{
    public class BladesRotate : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(0, 5, 0);
        }
    }
}