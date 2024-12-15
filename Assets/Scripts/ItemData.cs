using System;
using UnityEngine;

namespace Quiz
{
    [Serializable]
    public class ItemData
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite sprite;
        [SerializeField][Tooltip("���� �������� �� ������� �������")] private float angle;

        public string Name => name;
        public Sprite Sprite => sprite;
        public float Angle => angle;
    }
}
