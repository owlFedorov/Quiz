using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(GridGenerator))]
    [RequireComponent(typeof(ItemBundleArray))]
    [RequireComponent(typeof(ChallengeController))]
    public class ItemInitializer : MonoBehaviour
    {
        public delegate void ItemsInitializationHandler(Item[] items);
        public event ItemsInitializationHandler OnItemsInitialization;

        private GridGenerator gridGenerator;
        private ItemBundleArray itemBundleArray;
        private ChallengeController challengeController;
        private List<ItemData>[] itemsData;

        private void Awake()
        {
            gridGenerator = GetComponent<GridGenerator>();
            gridGenerator.OnGridGeneration += InitializeItems;

            itemBundleArray = GetComponent<ItemBundleArray>();
            itemsData = new List<ItemData>[itemBundleArray.ItemBundles.Length];

            for (int i = 0; i < itemsData.Length; i++)
            {
                itemsData[i] = itemBundleArray.ItemBundles[i].ItemsData.ToList();
            }
            challengeController = GetComponent<ChallengeController>();
        }

        private void OnDestroy()
        {
            gridGenerator.OnGridGeneration -= InitializeItems;
        }

        private void InitializeItems(Transform[] cells)
        {
            int bundleIndex = Random.Range(0, itemsData.Length);

            // Если в списке осталось меньше предметов, чем нужно, чтобы заполнить сетку, восстанавливаю список
            // В ТЗ об этом не было сказано, но если этого не сделать, то уже до первого рестарта на 3 уровне может не хватить цифр
            if (cells.Length > itemsData[bundleIndex].Count) itemsData[bundleIndex] = itemBundleArray.ItemBundles[bundleIndex].ItemsData.ToList();

            itemsData[bundleIndex] = Shuffle.List(itemsData[bundleIndex]);

            Item[] items = new Item[cells.Length];
            ItemData[] initItemsData = new ItemData[cells.Length];

            for (int i = 0; i < cells.Length; i++)
            {
                items[i] = cells[i].GetComponent<Item>();
                items[i].InitializeItem(itemsData[bundleIndex][i]);

                initItemsData[i] = itemsData[bundleIndex][i];
            }
            itemsData[bundleIndex].Remove(challengeController.ChooseRightAnswer(initItemsData));

            OnItemsInitialization?.Invoke(items);
        }
    }
}
