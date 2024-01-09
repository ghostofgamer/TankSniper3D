using UnityEngine;
using UnityEngine.UI;

namespace Tank3D
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Item _item;
        [SerializeField] private Image _image;

        private void Start()
        {
            _image.sprite = _item.Icon;
        }
    }
}