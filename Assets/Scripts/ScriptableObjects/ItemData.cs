using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Item Data", order = 50)]
    public class ItemData : ScriptableObject
    {
        public string itemName = "Item Name";
        public Sprite itemSprite;

    }
}