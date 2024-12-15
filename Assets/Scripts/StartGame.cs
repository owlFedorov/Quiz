using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(GridGenerator))]
    [RequireComponent(typeof(CellsAnimation))]
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private TaskText taskText;

        private GridGenerator gridGenerator;
        private CellsAnimation cellAnimationController;

        private void Awake()
        {
            gridGenerator = GetComponent<GridGenerator>();
            cellAnimationController = GetComponent<CellsAnimation>();
        }

        public void Start()
        {
            gridGenerator.DeleteCells();
            gridGenerator.GenerateGrid();

            taskText.TextAnimationPlay();
            cellAnimationController.CellAnimationPlay();
        }
    }
}
