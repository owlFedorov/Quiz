using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    [RequireComponent(typeof(Text))]
    public class TaskText : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        public void UpdateText(string value)
        {
            text.text = value;
        }

        public void TextAnimationPlay()
        {
            text.DOFade(1, 1).From(0);
        }
    }
}
