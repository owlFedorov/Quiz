using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(ItemInitializer))]
    public class ItemButtonsController : MonoBehaviour
    {
        private ItemInitializer itemInitializer;
        private Collider2D[] colliders;

        private void Awake()
        {
            itemInitializer = GetComponent<ItemInitializer>();
            itemInitializer.OnItemsInitialization += InitializeData;
        }

        private void OnDestroy()
        {
            itemInitializer.OnItemsInitialization -= InitializeData;
        }

        private void InitializeData(Item[] items)
        {
            colliders = new Collider2D[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                colliders[i] = items[i].GetComponent<Collider2D>();
            }
        }

        public void ItemButtonEnable(bool value)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = value;
            }
        }
    }
}
