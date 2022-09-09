using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Item))]
    public class Collectable : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) {

            Player player = collision.GetComponent<Player>();

            if (player != null) {
                Item item = GetComponent<Item>();
                player.inventory.AddItem(item);
                Destroy(this.gameObject);
            }
        }
    }
}