using Manager;
using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        public Inventory inventory;

        private void Awake()
        {
            inventory = new Inventory(21);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3Int position = new Vector3Int(
                    (int) transform.position.x,
                    (int) transform.position.y, 
                    0
                );

                if (GameManager.instance.tileManager.IsInteractable(position))
                {
                    GameManager.instance.tileManager.setInteractableTile(position);
                }
            }
        }

        public void DropItem(Item item)
        {
            Vector2 dropPosition = transform.position;

            Vector2 dropOffset = Random.insideUnitCircle * 1.5f;

            Item droppedItem = Instantiate(item, dropPosition + dropOffset, Quaternion.identity);
            droppedItem.rb.AddForce(dropOffset * .2f, ForceMode2D.Impulse);
        }
        
        public void DropItem(Item item, int qty)
        {
            for (int i = 0; i < qty; i++)
            {
                DropItem(item);
            }
        }
    }
}
