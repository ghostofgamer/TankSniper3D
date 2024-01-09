using UnityEngine;

namespace Tank3D
{
    [System.Serializable]
    public class TankData : MonoBehaviour
    {
        public float[] _position;
        private int _x = 0;
        private int _y = 1;
        private int _z = 2;
        private int _positionCount = 3;

        public TankData(Tank tank)
        {
            _position = new float[_positionCount];
            _position[_x] = tank.transform.position.x;
            _position[_y] = tank.transform.position.y;
            _position[_z] = tank.transform.position.z;
        }
    }
}