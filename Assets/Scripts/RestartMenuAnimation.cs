using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class RestartMenuAnimation : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private StartGame startGame;
        [SerializeField] private Image restartBackground;
        [SerializeField] private Image loadScreen;

        private Button restartButton;

        private void Awake()
        {
            restartButton = GetComponentInChildren<Button>();

            gameObject.SetActive(false);

            gridGenerator.OnEndGame += ShowRestartMenu;
        }

        private void OnDestroy()
        {
            gridGenerator.OnEndGame -= ShowRestartMenu;
        }

        private void ShowRestartMenu()
        {
            gameObject.SetActive(true);

            restartBackground.DOFade(0.5f, 1).From(0);

            restartButton.transform.DOScale(transform.localScale, 1).From(0).SetEase(Ease.OutBounce);
        }

        public void RestartOnClick()
        {
            loadScreen.gameObject.SetActive(true);

            loadScreen.DOFade(1, 2).From(0).OnComplete(() =>
            {
                loadScreen.gameObject.SetActive(false);
                gameObject.SetActive(false);
                startGame.Start();
            });
        }
    }
}
