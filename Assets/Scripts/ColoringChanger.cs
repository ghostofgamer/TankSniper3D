using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _MeshRenderer;

    private Material[] _materials;

    public void SetMaterial(Material material)
    {
        _materials = _MeshRenderer[0].materials;

        for (int i = 0; i < _materials.Length; i++)
            _materials[i] = material;

        for (int i = 0; i < _MeshRenderer.Length; i++)
            _MeshRenderer[i].materials = _materials;
    }
}