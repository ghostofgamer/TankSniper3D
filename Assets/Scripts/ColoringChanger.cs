using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _MeshRenderer;

    private Material[] materials;

    public void SetMaterial(Material material)
    {
        materials = _MeshRenderer[0].materials;

        for (int i = 0; i < materials.Length; i++)
            materials[i] = material;

        for (int i = 0; i < _MeshRenderer.Length; i++)
            _MeshRenderer[i].materials = materials;
    }
}