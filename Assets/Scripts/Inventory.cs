using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Slot> slots = new List<Slot>();

    [System.Serializable]
    public class Slot
    {
        public int amount;
        public int maxAmount;
        public CollectableType type;

        public Sprite icon;

        public Slot()
        {
            this.amount = 0;
            this.maxAmount = 99;
            this.type = CollectableType.NONE;
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

        public void AddItem(Collectable item)
        {
            if (CanAddItem())
            {
                this.type = item.type;
                this.icon = item.icon;
                amount++;
            }
        }

        public void RemoveItem() {
            if (amount > 0)
            {
                amount--;

                if (amount == 0)
                {
                    type = CollectableType.NONE;
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

    public void AddItem(Collectable item) {
        foreach (Slot slot in slots) {
            if (slot.type == item.type) {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots) {
            if (slot.type == CollectableType.NONE) {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void RemoveItem(int index)
    {
        slots[index].RemoveItem();
    }
}
