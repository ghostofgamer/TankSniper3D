using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private Image _image;

    private void Start()
    {
        _image.sprite = _item.Icon;
    }
}