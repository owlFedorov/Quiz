using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(fileName = "New ItemBundle", menuName = "Item Bundle", order = 1)]
    public class ItemBundle : ScriptableObject
    {
        [SerializeField] private ItemData[] itemsData;

        public ItemData[] ItemsData => itemsData;
    }
}
