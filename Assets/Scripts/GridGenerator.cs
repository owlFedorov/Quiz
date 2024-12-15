using System;
using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(GridDataArray))]
    [RequireComponent(typeof(CellsAnimation))]
    public class GridGenerator : MonoBehaviour
    {
        [SerializeField] private float gridMaxHeight = 0.7f;
        [SerializeField] private float gridMaxWidth = 0.7f;
        [SerializeField] private float cellMaxSize = 0.25f;
        [SerializeField] private GameObject cellPrefab;
        [SerializeField] private TaskText taskText;

        public delegate void GridGenerationHandler(Transform[] cells);
        public event GridGenerationHandler OnGridGeneration;

        public event Action OnEndGame;

        private GridDataArray gridDataArray;
        private CellsAnimation cellAnimationController;
        private Camera _camera;
        private int levelIndex;
        private Transform[] cells;

        private void Awake()
        {
            gridDataArray = GetComponent<GridDataArray>();
            cellAnimationController = GetComponent<CellsAnimation>();
            _camera = Camera.main;
        }

        public void GenerateGrid()
        {
            GridData data = GetLevelData();
            float cellSize = GetCellSize(data.RowCount, data.ColumnCount);

            Vector2 startPosition = new Vector2((data.ColumnCount - 1) * -cellSize / 2, (data.RowCount - 1) * cellSize / 2);
            Vector3 currentPosition = Vector3.zero;

            cells = new Transform[data.RowCount * data.ColumnCount];

            for (int r = 0; r < data.RowCount; r++)
            {
                for (int c = 0; c < data.ColumnCount; c++)
                {
                    currentPosition.x = startPosition.x + c * cellSize;
                    currentPosition.y = startPosition.y - r * cellSize;

                    cells[r * data.ColumnCount + c] = Instantiate(cellPrefab, currentPosition, Quaternion.identity, transform).transform;
                    cells[r * data.ColumnCount + c].localScale = Vector3.one * cellSize;
                }
            }
            OnGridGeneration?.Invoke(cells);
        }

        private GridData GetLevelData()
        {
            levelIndex++;

            return gridDataArray.GridsData[levelIndex - 1];
        }

        private float GetCellSize(int rowCount, int columnCount)
        {
            float viewportHeight = _camera.orthographicSize * 2;
            float viewportWidth = Screen.width * viewportHeight / Screen.height;
            float cellMaxSizeAbsolute = cellMaxSize * viewportHeight;

            if (viewportHeight - rowCount * cellMaxSizeAbsolute < viewportWidth - columnCount * cellMaxSizeAbsolute)
            {
                return Mathf.Clamp(viewportHeight * gridMaxHeight / rowCount, 0, cellMaxSizeAbsolute);
            }
            else
            {
                return Mathf.Clamp(viewportWidth * gridMaxWidth / columnCount, 0, cellMaxSizeAbsolute);
            }
        }

        public void CheckLevelIndex()
        {
            if (levelIndex == gridDataArray.GridsData.Length)
            {
                levelIndex = 0;
                OnEndGame?.Invoke();
            }
            else
            {
                DeleteCells();
                GenerateGrid();
            }
        }

        public void DeleteCells()
        {
            if (cells == null) return;

            for (int i = 0; i < cells.Length; i++)
            {
                Destroy(cells[i].gameObject);
            }
        }
    }
}
