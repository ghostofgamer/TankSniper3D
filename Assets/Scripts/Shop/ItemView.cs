using Assets.Scripts.ScriptableObjects.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop
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