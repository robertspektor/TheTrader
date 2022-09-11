using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Toolbar_UI : MonoBehaviour
    {
        [SerializeField] private List<Slots_UI> toolbarSlots = new List<Slots_UI>();

        private Slots_UI selectedSlot;
        
        private int maxSlots = 8;

        void Start()
        {
            SelectSlot(0);
        }

        void Update()
        {
            CheckAlphaNumericKeys();
        }

        public void SelectSlot(int index)
        {
            if (toolbarSlots.Count == maxSlots)
            {
                if (selectedSlot != null)
                {
                    selectedSlot.toggleHightlight();
                }
                
                selectedSlot = toolbarSlots[index];
                
                selectedSlot.toggleHightlight();
                
                 Debug.Log("Selected Slot: " + selectedSlot.name);
            }
        }
        
        private void CheckAlphaNumericKeys()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectSlot(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectSlot(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectSlot(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectSlot(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectSlot(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SelectSlot(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SelectSlot(6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                SelectSlot(7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                SelectSlot(8);
            }
        }
    }
}