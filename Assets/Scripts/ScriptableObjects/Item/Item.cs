using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Item
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Item/CreateNewItem", order = 51)]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _icon;

        public Sprite Icon => _icon;
    }
}