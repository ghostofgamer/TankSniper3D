using UnityEngine;

namespace Assets.Scripts.SaveLoad
{
    [System.Serializable]
    public struct Vec3
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