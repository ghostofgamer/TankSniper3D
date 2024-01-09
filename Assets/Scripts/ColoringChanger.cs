using UnityEngine;

namespace Tank3D
{
    public class ColoringChanger : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] _MeshRenderer;

        private Material[] _materials;
        private int _zero = 0;

        public void SetMaterial(Material material)
        {
            _materials = _MeshRenderer[_zero].materials;

            for (int i = 0; i < _materials.Length; i++)
                _materials[i] = material;

            for (int i = 0; i < _MeshRenderer.Length; i++)
                _MeshRenderer[i].materials = _materials;
        }
    }
}