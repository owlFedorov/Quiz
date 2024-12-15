using System.Collections;
using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(ItemButtonsController))]
    [RequireComponent(typeof(GridGenerator))]
    public class ChallengeController : MonoBehaviour
    {
        [SerializeField] private TaskText taskText;

        private ItemButtonsController itemButtonsController;
        private GridGenerator gridGenerator;
        private string rightAnswer;

        private void Awake()
        {
            itemButtonsController = GetComponent<ItemButtonsController>();
            gridGenerator = GetComponent<GridGenerator>();
        }

        public ItemData ChooseRightAnswer(ItemData[] data)
        {
            int rnd = Random.Range(0, data.Length);
            rightAnswer = data[rnd].Name;

            taskText.UpdateText("Find " + rightAnswer);

            return data[rnd];
        }

        public bool CheckAnswer(string answer)
        {
            itemButtonsController.ItemButtonEnable(false);

            if (answer == rightAnswer)
            {
                StartCoroutine(LoadNextLevel());

                return true;
            }
            else
            {
                StartCoroutine(ContinueGame());

                return false;
            }
        }

        private IEnumerator ContinueGame()
        {
            yield return new WaitForSeconds(0.5f);

            itemButtonsController.ItemButtonEnable(true);
        }

        private IEnumerator LoadNextLevel()
        {
            yield return new WaitForSeconds(2);

            gridGenerator.CheckLevelIndex();
        }
    }
}
