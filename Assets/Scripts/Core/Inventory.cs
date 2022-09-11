using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class Inventory
    {
        public List<Slot> slots = new List<Slot>();

        [System.Serializable]
        public class Slot
        {
            public int amount;
            public int maxAmount;
            public string itemName;

            public Sprite icon;

            public Slot()
            {
                this.amount = 0;
                this.maxAmount = 99;
                this.itemName = "";
            }

            public bool CanAddItem()
            {
                if (amount < maxAmount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void AddItem(Item item)
            {
                if (CanAddItem())
                {
                    this.itemName = item.data.itemName;
                    this.icon = item.data.itemSprite;
                    amount++;
                }
            }

            public void RemoveItem() {
                if (amount > 0)
                {
                    amount--;

                    if (amount == 0)
                    {
                        itemName = "";
                        icon = null;
                    }
                }
            }
        }

        public Inventory(int numSlots) {
        
            for (int i = 0; i < numSlots; i++) {
                Slot slot = new Slot();
                slots.Add(slot);
            }
        }

        public void AddItem(Item item) {
            foreach (Slot slot in slots) {
                if (slot.itemName == item.data.itemName) {
                    slot.AddItem(item);
                    return;
                }
            }

            foreach (Slot slot in slots) {
                if (slot.itemName == "") {
                    slot.AddItem(item);
                    return;
                }
            }
        }

        public void RemoveItem(int index)
        {
            slots[index].RemoveItem();
        }
        
        public void RemoveItem(int index, int qty)
        {
            if (slots[index].amount >= qty)
            {
                for (int i = 0; i < qty; i++)
                {
                    RemoveItem(index);
                }
            }
        }
    }
}
