using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Item _coloring;
    [SerializeField] private Image _image;

    private void Start()
    {
        _image.sprite = _coloring.Icon;
    }
}
