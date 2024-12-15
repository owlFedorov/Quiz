using UnityEngine;

namespace Quiz
{
    public class ItemBundleArray : MonoBehaviour
    {
        [SerializeField] private ItemBundle[] itemBundles;

        public ItemBundle[] ItemBundles => itemBundles;
    }
}
