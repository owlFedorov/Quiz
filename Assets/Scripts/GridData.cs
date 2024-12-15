using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(fileName = "New GridData", menuName = "Grid Data", order = 2)]
    public class GridData : ScriptableObject
    {
        [SerializeField] private int rowCount;
        [SerializeField] private int columnCount;

        public int RowCount => rowCount;
        public int ColumnCount => columnCount;
    }
}
