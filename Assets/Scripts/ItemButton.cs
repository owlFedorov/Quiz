using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(Item))]
    [RequireComponent(typeof(ItemAnimation))]
    public class ItemButton : MonoBehaviour
    {
        private Item item;
        private ItemAnimation itemAnimation;

        private void Awake()
        {
            item = GetComponent<Item>();
            itemAnimation = GetComponent<ItemAnimation>();
        }

        private void OnMouseDown()
        {
            if (transform.root.GetComponent<ChallengeController>().CheckAnswer(item.Name) == true)
            {
                itemAnimation.Correctly();
            }
            else
            {
                itemAnimation.Wrong();
            }
        }
    }
}
