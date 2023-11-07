using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMask : MonoBehaviour
{
    private int _layerNumber = 6;
    private int _layerMask;

    private void Start()
    {
        _layerMask = 1 << _layerNumber;
    }

    private void Update()
    {
            
    }
}
