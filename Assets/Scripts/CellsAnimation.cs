using System.Collections;
using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(GridGenerator))]
    public class CellsAnimation : MonoBehaviour
    {
        private GridGenerator gridGenerator;
        private Transform[] cells;

        private void Awake()
        {
            gridGenerator = GetComponent<GridGenerator>();
            gridGenerator.OnGridGeneration += SetCells;
        }

        private void OnDestroy()
        {
            gridGenerator.OnGridGeneration -= SetCells;
        }

        private void SetCells(Transform[] cells)
        {
            this.cells = cells;
        }

        public void CellAnimationPlay()
        {
            cells = Shuffle.Array(cells);

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].gameObject.SetActive(false);
            }
            StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].GetComponent<ItemAnimation>().Spawn();

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
