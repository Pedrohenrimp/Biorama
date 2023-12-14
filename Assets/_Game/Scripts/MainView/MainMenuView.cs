using Biorama.Essentials;
using Biorama.Popups;
using Biorama.ScriptableAssets.Book;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        [CustomName("Continue Button")]
        private Button mContinueButton;

        [SerializeField]
        [CustomName("Cut Scene Object")]
        private GameObject mCutSceneObject;

        [SerializeField]
        [CustomName("Transition Animator")]
        private Animator mTransitionAnimator;

        private void Start()
        {
            mContinueButton.interactable = ServiceLocator.Instance.PlayerGameData.HasSavedGame;
        }

        private async void OnEnable()
        {
            mTransitionAnimator.gameObject.SetActive(true);
            mTransitionAnimator.Play("FadeOut");
            await Task.Delay(500);
            mTransitionAnimator.gameObject.SetActive(false);
        }
        public void OnSettingsButtonClicked()
        {
            SettingsPopup.Instance.Show();
        }

        public void OnNewGameButtonClicked()
        {
            mCutSceneObject.SetActive(true);
        }

        public void OnContinueButtonClicked()
        {
            ServiceLocator.Instance.CurrentScene = SceneType.PlayScene;
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
            ServiceLocator.Instance.IsGamePlaying = true;
            ServiceLocator.Instance.CurrentBiome = ServiceLocator.Instance.PlayerGameData.GameData.CurrentBiome;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
