using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingRotate : MonoBehaviour
{
    [SerializeField] private Image _image;

    private readonly float _speed = 165f;

    private void Update()
    {
        _image.transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}
