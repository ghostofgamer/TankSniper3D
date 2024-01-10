using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    [System.Serializable]
    public class Vec3 : MonoBehaviour
    {
        public float X;
        public float Y;
        public float Z;

        public Vec3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}