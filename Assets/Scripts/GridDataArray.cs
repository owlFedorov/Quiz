using UnityEngine;

namespace Quiz
{
    public class GridDataArray : MonoBehaviour
    {
        [SerializeField] private GridData[] gridsData;

        public GridData[] GridsData => gridsData;
    }
}
