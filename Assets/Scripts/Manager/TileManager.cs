using UnityEngine;
using UnityEngine.Tilemaps;

namespace Manager
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private Tilemap interactableTilemap;

        [SerializeField] private Tile hiddenInteractableTilemap;

        public Tile PlowedTile;

        void Start()
        {
            foreach (var position in interactableTilemap.cellBounds.allPositionsWithin)
            {
                if (interactableTilemap.HasTile(position))
                {
                    interactableTilemap.SetTile(position, hiddenInteractableTilemap);
                }
            }
        }

        public bool IsInteractable(Vector3Int position)
        {
            TileBase tile = interactableTilemap.GetTile(position);

            if (tile != null && tile.name == "Interactable")
            {
                return true;
            }
        
            return false;
        }

        public void setInteractableTile(Vector3Int position)
        {
            interactableTilemap.SetTile(position, PlowedTile);
        }
    }
}