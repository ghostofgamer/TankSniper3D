using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressPoint : MonoBehaviour
{
    [SerializeField] private Image _imageNotComplite;
    [SerializeField] private Image _imageComplite;

    public void Complite()
    {
        _imageNotComplite.gameObject.SetActive(false);
        _imageComplite.gameObject.SetActive(true);
    }

    public void NoComplite()
    {
        _imageNotComplite.gameObject.SetActive(true);
        _imageComplite.gameObject.SetActive(false);
    }
}
