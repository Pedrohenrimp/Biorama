using Biorama.Essentials;
using Biorama.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace Biorama.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        [CustomName("Continue Button")]
        private Button mContinueButton;

        private void OnEnable()
        {
            mContinueButton.interactable = ServiceLocator.Instance.PlayerGameData.HasSavedGame;
        }
        public void OnSettingsButtonClicked()
        {
            SettingsPopup.Instance.Show();
        }

        public void OnNewGameButtonClicked()
        {
            ServiceLocator.Instance.PlayerGameData.ClearGameData();
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
        }

        public void OnContinueButtonClicked()
        {
            ServiceLocator.Instance.CustomSceneManager.LoadScene(SceneType.PlayScene);
        }
    }
}
