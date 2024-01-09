using UnityEngine;

namespace Tank3D
{
    public class BladesRotate : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(0, 5, 0);
        }
    }
}