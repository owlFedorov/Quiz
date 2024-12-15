using System;
using UnityEngine;

namespace Quiz
{
    [Serializable]
    public class ItemData
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite sprite;
        [SerializeField][Tooltip("”гол поворота по часовой стрелке")] private float angle;

        public string Name => name;
        public Sprite Sprite => sprite;
        public float Angle => angle;
    }
}
