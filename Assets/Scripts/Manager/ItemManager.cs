using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Manager
{
    public class ItemManager : MonoBehaviour
    {
        public Item[] items;

        private Dictionary<string, Item> _nameToItemsDict = 
            new Dictionary<string, Item>();

        private void Awake()
        {
            foreach (Item item in items)
            {
                AddItem(item);
            }
        }

        private void AddItem(Item item)
        {
            if (_nameToItemsDict.ContainsKey(item.data.itemName))
            {
                Debug.LogError("Item with type " + item.data.itemName + " already exists");
            }
            else
            {
                _nameToItemsDict.Add(item.data.itemName, item);
            }
        }

        public Item GetItemByName(string key)
        {
            if (_nameToItemsDict.ContainsKey(key))
            {
                return _nameToItemsDict[key];
            }
            
            Debug.LogError("Item with type " + key + " does not exist");
            return null;
        }


    }
}
