using UnityEngine;

namespace Quiz
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private string _name;

        public string Name => _name;

        public void InitializeItem(ItemData data)
        {
            _name = data.Name;

            Vector2 size = spriteRenderer.size;

            if (data.Sprite.rect.width > data.Sprite.rect.height)
            {
                size.y = data.Sprite.rect.height * spriteRenderer.size.x / data.Sprite.rect.width;
            }
            else
            {
                size.x = data.Sprite.rect.width * spriteRenderer.size.y / data.Sprite.rect.height;
            }
            spriteRenderer.size = size;
            spriteRenderer.sprite = data.Sprite;

            if (data.Angle != 0) spriteRenderer.transform.rotation = Quaternion.Euler(Vector3.forward * -data.Angle);
        }
    }
}
