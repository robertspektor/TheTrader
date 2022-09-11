using System.Collections.Generic;
using Core;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Inventory_UI : MonoBehaviour
    {
        public GameObject inventoryPanel;

        public Player player;

        public List<Slots_UI> slots = new List<Slots_UI>();

        private Slots_UI draggedSlot;
        
        private Image draggedItemImage;
        
        [SerializeField] private Canvas canvas;

        private bool dragSingle;
        
        private void Awake()
        {
            canvas = FindObjectOfType<Canvas>();
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleInventory();
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("Shift");
                dragSingle = true;
            }
            else
            {
                dragSingle = false;
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
    
        public void Remove()
        {
            Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
                player.inventory.slots[draggedSlot.slotId].itemName
            );

            if (itemToDrop != null)
            {
                Debug.Log(dragSingle);
                if (dragSingle)
                {
                    player.DropItem(itemToDrop);
                
                    player.inventory.RemoveItem(draggedSlot.slotId);    
                }
                else
                {
                    player.DropItem(
                        itemToDrop, 
                        player.inventory.slots[draggedSlot.slotId].amount
                    );
                
                    player.inventory.RemoveItem(
                        draggedSlot.slotId, 
                        player.inventory.slots[draggedSlot.slotId].amount
                    );    
                }
                
                
                Refresh();
            }

            draggedSlot = null;
        }
        
        public void SlotBeginDrag(Slots_UI slot)
        {
            draggedSlot = slot;
            draggedItemImage = Instantiate(draggedSlot.itemIcon);
            draggedItemImage.transform.SetParent(canvas.transform);
            draggedItemImage.raycastTarget = false;
            draggedItemImage.rectTransform.sizeDelta = new Vector2(50, 50);
            
            MoveToMousePosition(draggedItemImage.gameObject);
        }

        public void SlotDrag()
        {
            MoveToMousePosition(draggedItemImage.gameObject);
        }
        
        public void SlotEndDrag()
        {
            Destroy(draggedItemImage.gameObject);
            draggedItemImage = null;
        }
        
        public void SlotDrop(Slots_UI slot)
        {
            
            Debug.Log("Drop" + draggedSlot.name + " on " + slot.name);
        }
        
        private void MoveToMousePosition(GameObject obj)
        {
            if (canvas != null)
            {
                Vector2 position;
                
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.transform as RectTransform, 
                    Input.mousePosition, 
                    null, out position
                );
                
                obj.transform.position = canvas.transform.TransformPoint(position);
            }
        }
    }
}
