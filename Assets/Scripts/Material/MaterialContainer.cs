using UnityEngine;

namespace Tank3D
{
    public class MaterialContainer : MonoBehaviour
    {
        [SerializeField] private Material[] _materials;
        [SerializeField] private Load _load;

        private int _startIndex = 0;

        public Material GetColor()
        {
            int index = _load.Get(Save.Color, _startIndex);
            return _materials[index];
        }
    }
}