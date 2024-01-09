using UnityEngine;

namespace Tank3D
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item/CreateNewItem", order = 51)]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _icon;

        public Sprite Icon => _icon;
    }
}