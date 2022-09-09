using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public ItemManager itemManager;

        public TileManager tileManager;
     

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(this.gameObject);

            itemManager = GetComponent<ItemManager>();
            tileManager = GetComponent<TileManager>();
        }
    }
}
