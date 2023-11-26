using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _size;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            _rectTransform.GetComponent<RectTransform>();
            _rectTransform.sizeDelta = new Vector3(_size, _size, 0);
        }
        else
            return;
    }
}
