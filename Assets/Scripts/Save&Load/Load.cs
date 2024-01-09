using UnityEngine;

namespace Tank3D
{
    public class Load : MonoBehaviour
    {
        public int Get(string name, int number)
        {
            if (PlayerPrefs.HasKey(name))
                return PlayerPrefs.GetInt(name);

            return number;
        }

        public float Get(string name, float number)
        {
            if (PlayerPrefs.HasKey(name))
                return PlayerPrefs.GetFloat(name);

            return number;
        }
    }
}