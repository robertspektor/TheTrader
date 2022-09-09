using System.Collections.Generic;
using Core;
using Manager;
using UnityEngine;

namespace UI
{
    public class Inventory_UI : MonoBehaviour
    {
        public GameObject inventoryPanel;

        public Player player;

        public List<Slots_UI> slots = new List<Slots_UI>();

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleInventory();
            }
        }

        public void ToggleInventory()
        {
            // toggle inventory
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
                Refresh();
            }
        }  

        public void Refresh()
        {
            if (slots.Count == player.inventory.slots.Count)  {
                for (int i = 0; i < slots.Count; i++)
                {
                    if (player.inventory.slots[i].itemName != "")
                    {
                        slots[i].SetItem(player.inventory.slots[i]);
                    }
                    else
                    {
                        slots[i].ClearSlot();
                    }
                }
            }
        }
    
        public void Remove(int slotID)
        {
            Debug.Log("Remove");
            Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
                player.inventory.slots[slotID].itemName
            );

            if (itemToDrop != null)
            {
                player.DropItem(itemToDrop);
                player.inventory.RemoveItem(slotID);
                Refresh();
            }
        }
    }
}
